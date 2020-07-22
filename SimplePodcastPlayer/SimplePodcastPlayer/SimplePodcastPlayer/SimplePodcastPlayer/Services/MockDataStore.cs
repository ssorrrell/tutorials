using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplePodcastPlayer.Models;

namespace SimplePodcastPlayer.Services
{
    public class MockDataStore : IDataStore<SavedFeedItem>
    {
        readonly SavedFeedList items;

        public MockDataStore()
        {
            items.FeedList = new List<SavedFeedItem>();
            items.FeedList.Add(new SavedFeedItem { ID = 0, Name = "First item", Description = "This is an item description." });
            items.FeedList.Add(new SavedFeedItem { ID = 0, Name = "Second item", Description = "This is an item description." });
            items.FeedList.Add(new SavedFeedItem { ID = 0, Name = "Third item", Description = "This is an item description." });
            items.FeedList.Add(new SavedFeedItem { ID = 0, Name = "Fourth item", Description = "This is an item description." });
        }

        public async Task<bool> AddItemAsync(SavedFeedItem item)
        {
            items.FeedList.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(SavedFeedItem item)
        {
            var oldItem = items.FeedList.Where((SavedFeedItem arg) => arg.ID == item.ID).FirstOrDefault();
            items.FeedList.Remove(oldItem);
            items.FeedList.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.FeedList.Where((SavedFeedItem arg) => arg.ID == id).FirstOrDefault();
            items.FeedList.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<SavedFeedItem> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FeedList.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<SavedFeedItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items.FeedList);
        }
    }
}