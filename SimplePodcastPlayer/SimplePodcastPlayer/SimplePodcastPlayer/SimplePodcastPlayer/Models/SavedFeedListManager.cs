using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SimplePodcastPlayer.Common;
using SQLite;
using System.Xml.Linq;
using System.Net.Http;
using Microsoft.Toolkit.Parsers.Rss;

namespace SimplePodcastPlayer.Models
{
    public class SavedFeedListManager
    {
        static bool initialized = false;

        public SavedFeedListManager()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        private async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.DbConnection.TableMappings.Any(m => m.MappedType.Name == typeof(SavedFeedItem).Name))
                {
                    await Database.DbConnection.CreateTablesAsync(CreateFlags.None, typeof(SavedFeedItem)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<SavedFeedItem>> GetAllItemsAsync()
        {
            return Database.DbConnection.Table<SavedFeedItem>().ToListAsync();
        }

        public async Task<List<SavedFeedItem>> GetItemsNotDoneAsync()
        {
            return await Database.DbConnection.QueryAsync<SavedFeedItem>("SELECT * FROM [SavedFeed]");
        }

        public async Task<SavedFeedItem> GetItemAsync(int id)
        {
            return await Database.DbConnection.Table<SavedFeedItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(SavedFeedItem item)
        {
            if (item.ID != 0)
            {
                return Database.DbConnection.UpdateAsync(item);
            }
            else
            {
                return Database.DbConnection.InsertAsync(item);
            }
        }

        public Task<int> DeleteAsync<SavedFeedItem>(int ID)
        {
            return Database.DbConnection.DeleteAsync<SavedFeedItem>(ID);
        }

        public Task<int> DeleteItemAsync(SavedFeedItem item)
        {
            return Database.DbConnection.DeleteAsync(item);
        }

        public Task<int> DeleteAllAsync()
        {
            return Database.DbConnection.DeleteAllAsync<SavedFeedItem>();
        }

        /// <summary>
        /// Retrieves feed data from the server and updates the appropriate FeedViewModel properties.
        /// </summary>
        /*private static async Task<bool> TryGetFeedAsync(SavedFeedItem feedViewModel, CancellationToken? cancellationToken = null)
        {
            try
            {
                var feed = await new SyndicationClient().RetrieveFeedAsync(feedViewModel.Link);

                if (cancellationToken.HasValue && cancellationToken.Value.IsCancellationRequested) return false;

                feedViewModel.LastSyncDateTime = DateTime.Now;
                feedViewModel.Name = String.IsNullOrEmpty(feedViewModel.Name) ? feed.Title.Text : feedViewModel.Name;
                feedViewModel.Description = feed.Subtitle?.Text ?? feed.Title.Text;

                feed.Items.Select(item => new ArticleViewModel
                {
                    Title = item.Title.Text,
                    Summary = item.Summary == null ? string.Empty :
                        item.Summary.Text.RegexRemove("\\&.{0,4}\\;").RegexRemove("<.*?>"),
                    Author = item.Authors.Select(a => a.NodeValue).FirstOrDefault(),
                    Link = item.ItemUri ?? item.Links.Select(l => l.Uri).FirstOrDefault(),
                    PublishedDate = item.PublishedDate
                })
                .ToList().ForEach(article =>
                {
                    var favorites = AppShell.Current.ViewModel.FavoritesFeed;
                    var existingCopy = favorites.Articles.FirstOrDefault(a => a.Equals(article));
                    article = existingCopy ?? article;
                    if (!feedViewModel.Articles.Contains(article)) feedViewModel.Articles.Add(article);
                });
                feedViewModel.IsInError = false;
                feedViewModel.ErrorMessage = null;
                return true;
            }
            catch (Exception)
            {
                if (!cancellationToken.HasValue || !cancellationToken.Value.IsCancellationRequested)
                {
                    feedViewModel.IsInError = true;
                    feedViewModel.ErrorMessage = feedViewModel.Articles.Count == 0 ? BAD_URL_MESSAGE : NO_REFRESH_MESSAGE;
                }
                return false;
            }
        }*/

        /*private async Task<List<SavedFeedItem>> ParseFeed(string rss)
        {   //James Montemagno
            return await Task.Run(() =>
            {
                var xdoc = XDocument.Parse(rss);
                var id = 0;
                return (from item in xdoc.Descendants("item")
                        select new SavedFeedItem
                        {
                            Title = (string)item.Element("title"),
                            Description = (string)item.Element("description"),
                            Link = (string)item.Element("link"),
                            PublishDate = (string)item.Element("pubDate"),
                            AuthorEmail = (string)item.Element("author"),
                            Id = id++
                        }).ToList();
            });
        }*/

        /*public async Task LoadItemsAsync()
        {
            var client = new RssClient();
            var tcs = new TaskCompletionSource<RssFeed>();
            client.GetRssFeed(new Uri(FeedUrl), tcs.SetResult);
            var feed = await tcs.Task;
            Items = feed.Items.Select(item => new RssItem()
            {
                Title = item.Title,
                Description = item.Description,
                Link = item.Link
            });
        }*/

        public async Task<IEnumerable<RssSchema>> Parse(string url)
        {
            string feed = null;

            using (var client = new HttpClient())
            {
                feed = await client.GetStringAsync(url);
            }

            if (feed == null) return new List<RssSchema>();

            var parser = new RssParser();
            var rss = parser.Parse(feed);
            return rss;
        }

        private const string BAD_URL_MESSAGE = "Hmm... Are you sure this is an RSS URL?";
        private const string NO_REFRESH_MESSAGE = "Sorry. We can't get more articles right now.";
    }
}
