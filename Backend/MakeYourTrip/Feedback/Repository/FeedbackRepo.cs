using Feedback.Context;
using Feedback.Interfaces;
using Feedback.Models;
using Microsoft.EntityFrameworkCore;

namespace Feedback.Repository
{
    public class FeedbackRepo : IFeedBackCRUD<int, TourFeedBack>
    {
        private readonly FeedbackContext _context;
        private readonly ILogger<FeedbackRepo> _logger;

        public FeedbackRepo(FeedbackContext context, ILogger<FeedbackRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<TourFeedBack?> Add(TourFeedBack item)
        {
            try
            {
                _context.TourFeedBacks.Add(item);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Feedback added successfully.");
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding feedback.");
                throw new Exception("Error occurred while adding feedback.", ex);
            }
        }

        public async Task<TourFeedBack?> Delete(int key)
        {
            try
            {
                var feedback = await _context.TourFeedBacks.FindAsync(key);
                if (feedback != null)
                {
                    _context.TourFeedBacks.Remove(feedback);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Feedback deleted successfully.");
                }
                return feedback;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting feedback.");
                throw new Exception("Error occurred while deleting feedback.", ex);
            }
        }
        public async Task<TourFeedBack?> Get(int key)
        {
            try
            {
                var feedback = await _context.TourFeedBacks.FindAsync(key);
                _logger.LogInformation("Feedback retrieved successfully.");
                return feedback;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting feedback.");
                throw new Exception("Error occurred while getting feedback.", ex);
            }
        }


        public async Task<ICollection<TourFeedBack>?> GetAll()
        {
            try
            {
                var feedback = await _context.TourFeedBacks.ToListAsync();
                if (feedback.Count > 0)
                {
                    _logger.LogInformation("All feedbacks retrieved successfully.");
                    return feedback;
                }
                else
                {
                    _logger.LogInformation("No feedbacks available.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting feedbacks.");
                throw new Exception("Error occurred while getting feedbacks.", ex);
            }
        }


        public async Task<TourFeedBack?> Update(TourFeedBack item)
        {
            try
            {
                _context.TourFeedBacks.Update(item);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Feedback updated successfully.");
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating feedback.");
                throw new Exception("Error occurred while updating feedback.", ex);
            }
        }
    }
}
