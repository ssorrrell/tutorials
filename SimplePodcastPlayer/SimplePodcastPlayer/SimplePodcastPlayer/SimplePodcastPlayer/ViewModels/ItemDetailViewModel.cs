using System;

using SimplePodcastPlayer.Models;

namespace SimplePodcastPlayer.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public SavedFeedItem Item { get; set; }
        public ItemDetailViewModel(SavedFeedItem item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
