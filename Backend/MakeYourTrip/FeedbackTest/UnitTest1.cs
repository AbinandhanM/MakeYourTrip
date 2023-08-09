using Feedback.Context;
using Feedback.Models;
using Feedback.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FeedbackTest
{
    [TestClass]
    public class FeedbackRepoTests
    {
        private DbContextOptions<FeedbackContext> GetInMemoryDatabaseOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<FeedbackContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }

        [TestMethod]
        public async Task AddFeedback()
        {
            // Arrange
            var databaseName = Guid.NewGuid().ToString();
            var options = GetInMemoryDatabaseOptions(databaseName);

            using (var context = new FeedbackContext(options))
            {
                context.Database.EnsureCreated(); // Create the in-memory database

                var feedbackRepo = new FeedbackRepo(context, new NullLogger<FeedbackRepo>());

                var feedback = new TourFeedBack
                {
                    TravellerName = "John Doe",
                    TouristSpotName = "Example Spot",
                    Email = "johndoe@example.com",
                    FeedbackText = "Great experience!",
                    Rating = 5,
                    DateSubmitted = DateTime.UtcNow
                };

                // Act
                var addedFeedback = await feedbackRepo.Add(feedback);

                // Assert
                Assert.IsNotNull(addedFeedback);
                Assert.AreEqual(feedback.TravellerName, addedFeedback.TravellerName);
                // Additional assertions if needed
            }

            // The context will be disposed of at the end of using block
            // and the in-memory database will be deleted.

        }

        [TestMethod]
        public async Task UpdateFeedback()
        {
            // Arrange
            var databaseName = Guid.NewGuid().ToString();
            var options = GetInMemoryDatabaseOptions(databaseName);

            using (var context = new FeedbackContext(options))
            {
                context.Database.EnsureCreated();

                var feedbackRepo = new FeedbackRepo(context, new NullLogger<FeedbackRepo>());

                var feedback = new TourFeedBack
                {
                    TravellerName = "John Doe",
                    TouristSpotName = "Example Spot",
                    Email = "johndoe@example.com",
                    FeedbackText = "Great experience!",
                    Rating = 5,
                    DateSubmitted = DateTime.UtcNow
                };

                var addedFeedback = await feedbackRepo.Add(feedback);

                // Modify the feedback
                addedFeedback.TravellerName = "Updated Traveller";

                // Act
                var updatedFeedback = await feedbackRepo.Update(addedFeedback);

                // Assert
                Assert.IsNotNull(updatedFeedback);
                Assert.AreEqual("Updated Traveller", updatedFeedback.TravellerName);
                // Additional assertions if needed
            }
        }

        [TestMethod]
        public async Task GetFeedbackbyid()
        {
            // Arrange
            var databaseName = Guid.NewGuid().ToString();
            var options = GetInMemoryDatabaseOptions(databaseName);

            using (var context = new FeedbackContext(options))
            {
                context.Database.EnsureCreated();

                var feedbackRepo = new FeedbackRepo(context, new NullLogger<FeedbackRepo>());

                var feedback = new TourFeedBack
                {
                    TravellerName = "John Doe",
                    TouristSpotName = "Example Spot",
                    Email = "johndoe@example.com",
                    FeedbackText = "Great experience!",
                    Rating = 5,
                    DateSubmitted = DateTime.UtcNow
                };

                var addedFeedback = await feedbackRepo.Add(feedback);

                // Act
                var retrievedFeedback = await feedbackRepo.Get(addedFeedback.FeedbackId);

                // Assert
                Assert.IsNotNull(retrievedFeedback);
                Assert.AreEqual(addedFeedback.FeedbackId, retrievedFeedback.FeedbackId);
                // Additional assertions if needed
            }
        }
        [TestMethod]
        public async Task GetAllFeedback()
        {
            // Arrange
            var databaseName = Guid.NewGuid().ToString();
            var options = GetInMemoryDatabaseOptions(databaseName);

            using (var context = new FeedbackContext(options))
            {
                context.Database.EnsureCreated();

                var feedbackRepo = new FeedbackRepo(context, new NullLogger<FeedbackRepo>());

                var feedback1 = new TourFeedBack
                {
                    TravellerName = "John Doe",
                    TouristSpotName = "Example Spot 1",
                    Email = "johndoe@example.com",
                    FeedbackText = "Great experience!",
                    Rating = 5,
                    DateSubmitted = DateTime.UtcNow
                };

                var feedback2 = new TourFeedBack
                {
                    TravellerName = "Jane Doe",
                    TouristSpotName = "Example Spot 2",
                    Email = "janedoe@example.com",
                    FeedbackText = "Another great experience!",
                    Rating = 4,
                    DateSubmitted = DateTime.UtcNow
                };

                await AddFeedbackToDatabase(context, feedback1);
                await AddFeedbackToDatabase(context, feedback2);

                // Act
                var feedbacks = await feedbackRepo.GetAll();

                // Assert
                Assert.IsNotNull(feedbacks);
                Assert.AreEqual(2, feedbacks.Count);
            }
        }

        [TestMethod]
        public async Task DeleteFeedbackbyid()
        {
            // Arrange
            var databaseName = Guid.NewGuid().ToString();
            var options = GetInMemoryDatabaseOptions(databaseName);

            using (var context = new FeedbackContext(options))
            {
                context.Database.EnsureCreated();

                var feedbackRepo = new FeedbackRepo(context, new NullLogger<FeedbackRepo>());

                var feedback = new TourFeedBack
                {
                    TravellerName = "John Doe",
                    TouristSpotName = "Example Spot",
                    Email = "johndoe@example.com",
                    FeedbackText = "Great experience!",
                    Rating = 5,
                    DateSubmitted = DateTime.UtcNow
                };

                feedback = await AddFeedbackToDatabase(context, feedback);

                // Act
                var deletedFeedback = await feedbackRepo.Delete(feedback.FeedbackId);

                // Assert
                Assert.IsNotNull(deletedFeedback);
                Assert.AreEqual(feedback.FeedbackId, deletedFeedback.FeedbackId);
            }
        }
        private async Task<TourFeedBack> AddFeedbackToDatabase(FeedbackContext context, TourFeedBack feedback)
        {
            context.TourFeedBacks.Add(feedback);
            await context.SaveChangesAsync();
            return feedback;
        }
    }
}
