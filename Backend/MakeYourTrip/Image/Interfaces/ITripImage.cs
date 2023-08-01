using Image.Models;

namespace Image.Interfaces
{
    public interface ITripImage 
    {
        public Task<TripImage?> AddTripImage(TripImage tripImage);
        public Task<TripImage?> DeleteTripImage(int tripImageId);
        public Task<TripImage?> GetTripImage(int tripImageId);
        public Task<ICollection<TripImage>?> GetAllTripImages();
    }
}
