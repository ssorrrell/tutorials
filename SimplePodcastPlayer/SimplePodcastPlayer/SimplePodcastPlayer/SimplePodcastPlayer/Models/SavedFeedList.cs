using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePodcastPlayer.Models
{
    class SavedFeedList : BindableBase
    {
        /// <summary>
        /// Gets the name of the feed.
        /// </summary>
        public List<SavedFeedItem> FeedList { get { return _feedList; } set { SetProperty(ref _feedList, value); } }
        private List<SavedFeedItem> _feedList;

    }
}
