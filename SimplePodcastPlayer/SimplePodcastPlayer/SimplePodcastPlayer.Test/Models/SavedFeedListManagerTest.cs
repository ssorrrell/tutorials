using NUnit.Framework;
using SimplePodcastPlayer;
using SimplePodcastPlayer.Models;
using System.Threading.Tasks;

namespace SimplePodcastPlayer.Test
{
    public class SavedFeeListManagerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BasicManagerTests()
        {
            var manager = new SavedFeedListManager();
            Assert.IsNotNull(manager, "SavedFeedListManager not instantiated");
            var taskListSavedFeedItem = manager.GetAllItemsAsync();
            taskListSavedFeedItem.Wait();
            var taskListSavedFeedItemResult = taskListSavedFeedItem.Result;
            Assert.IsEmpty(taskListSavedFeedItemResult, "SavedFeedListManager.GetAllItemsAsync is empty");
            var taskSavedFeedItem = manager.GetItemAsync(0);
            taskSavedFeedItem.Wait();
            var taskSavedFeedItemResult = taskSavedFeedItem.Result;
            Assert.IsNull(taskSavedFeedItemResult, "SavedFeedListManager.GetItemAsync(0) is not null");
            var feedItem = new SavedFeedItem();
            feedItem.Name = "test";
            feedItem.Description = "unit test feed item";
            var taskInt = manager.SaveItemAsync(feedItem);
            taskInt.Wait();
            var saveAsyncResult = taskInt.Result;
            Assert.AreEqual(1, saveAsyncResult, "SavedFeedListManager.SaveItemAsync(feedItem) is not 1");
            taskInt = manager.DeleteItemAsync(feedItem);
            taskInt.Wait();
            var deleteItemAsyncResult = taskInt.Result;
            Assert.AreEqual(1, deleteItemAsyncResult, "SavedFeedListManager.DeleteItemAsync(feedItem) is not 1");
            taskInt = manager.DeleteAllAsync();
            taskInt.Wait();
            var deleteAllAsyncResult = taskInt.Result;
            Assert.AreEqual(0, deleteAllAsyncResult, "SavedFeedListManager.DeleteAllAsync() is not 0");
        }
    }
}