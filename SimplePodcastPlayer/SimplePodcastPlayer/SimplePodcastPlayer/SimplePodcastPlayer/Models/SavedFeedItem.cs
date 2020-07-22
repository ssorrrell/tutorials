using System;
using System.Runtime.Serialization;
using SQLite;

namespace SimplePodcastPlayer.Models
{
    public class SavedFeedItem : BindableBase
    {
        /// <summary>
        /// Gets the id of the feed.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int ID { get { return _id; } set { SetProperty(ref _id, value); } }
        private int _id;

        /// <summary>
        /// Gets the name of the feed.
        /// </summary>
        public string Name { get { return _name; } set { SetProperty(ref _name, value); } }
        private string _name;


        /// <summary>
        /// Gets a description of the feed.
        /// </summary>
        public string Description { get { return _description; } set { SetProperty(ref _description, value); } }
        private string _description;

        /// <summary>
        /// Gets or sets the URI of the feed.
        /// </summary>
        public Uri Link
        {
            get { return _link; }
            set { if (SetProperty(ref _link, value)) OnPropertyChanged(nameof(LinkAsString)); }
        }
        private Uri _link;

        /// <summary>
        /// Gets or sets a string representation of the URI of the feed.
        /// </summary>
        [IgnoreDataMember]
        public string LinkAsString
        {
            get { return Link?.OriginalString ?? String.Empty; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) return;

                if (!value.Trim().StartsWith("http://") && !value.Trim().StartsWith("https://"))
                {
                    IsInError = true;
                    ErrorMessage = NOT_HTTP_MESSAGE;
                }
                else
                {
                    Uri uri = null;
                    if (Uri.TryCreate(value.Trim(), UriKind.Absolute, out uri)) Link = uri;
                    else
                    {
                        IsInError = true;
                        ErrorMessage = INVALID_URL_MESSAGE;
                    }
                }
            }
        }


        /// <summary>
        /// Gets or sets a value that indicates whether the feed is currently being renamed. 
        /// </summary>
        [IgnoreDataMember] public bool IsInEdit { get { return _isInEdit; } set { SetProperty(ref _isInEdit, value); } }
        [IgnoreDataMember] private bool _isInEdit;

        /// <summary>
        /// Gets or sets a value that indicates whether the feed is currently loading article data. 
        /// </summary>
        [IgnoreDataMember]
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                if (SetProperty(ref _isLoading, value))
                {
                    OnPropertyChanged(nameof(IsInError));
                    //OnPropertyChanged(nameof(IsLoadingAndNotEmpty));
                    //OnPropertyChanged(nameof(IsNotFavoritesOrInError));
                    //OnPropertyChanged(nameof(IsInErrorAndEmpty));
                    //OnPropertyChanged(nameof(IsInErrorAndNotEmpty));
                }
            }
        }
        [IgnoreDataMember] private bool _isLoading;

        /// <summary>
        /// Gets or sets a value that indicates whether the feed is currently in an error state
        /// and is no longer trying to retrieve new data. 
        /// </summary>
        [IgnoreDataMember]
        public bool IsInError
        {
            get { return _isInError && !IsLoading; }
            set
            {
                if (SetProperty(ref _isInError, value))
                {
                    //OnPropertyChanged(nameof(IsNotFavoritesOrInError));
                    //OnPropertyChanged(nameof(IsInErrorAndEmpty));
                    //OnPropertyChanged(nameof(IsInErrorAndNotEmpty));
                }
            }
        }
        [IgnoreDataMember] private bool _isInError;

        /// <summary>
        /// Gets or sets the description of the current error, if the feed is in an error state. 
        /// </summary>
        [IgnoreDataMember] public string ErrorMessage { get { return _errorMessage; } set { SetProperty(ref _errorMessage, value); } }
        [IgnoreDataMember] public string _errorMessage;

        /// <summary>
        /// Determines whether the specified object is equal to the current object. 
        /// </summary>
        public override bool Equals(object obj) =>
            obj is SavedFeedItem ? (obj as SavedFeedItem).GetHashCode() == GetHashCode() : false;

        /// <summary>
        /// Returns the hash code of the FeedViewModel, which is based on 
        /// a string representation the Link value, using only the host and path.  
        /// </summary>
        public override int GetHashCode() =>
            Link?.GetComponents(UriComponents.Host | UriComponents.Path, UriFormat.Unescaped).GetHashCode() ?? 0;

        /// <summary>
        /// Gets or sets the date and time of the last successful article retrieval. 
        /// </summary>
        public DateTime LastSyncDateTime { get { return _lastSyncDateTime; } set { SetProperty(ref _lastSyncDateTime, value); } }
        private DateTime _lastSyncDateTime;

        private const string NOT_HTTP_MESSAGE = "Sorry. The URL must begin with http:// or https://";
        private const string INVALID_URL_MESSAGE = "Sorry. That is not a valid URL.";
    }
}
