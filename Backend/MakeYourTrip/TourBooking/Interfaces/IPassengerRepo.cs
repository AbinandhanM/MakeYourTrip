using TourBooking.Models;

namespace TourBooking.Interfaces
{
    public interface IPassengerRepo
    {
        public Task<Passenger?> AddPassenger(Passenger passenger);
        public Task<Passenger?> DeletePassenger(int id);
        public Task<Passenger?> GetPassenger(int id);
        public Task<List<Passenger>?> GetAllPassenger();
        public Task<Passenger?> UpdatePassenger(Passenger passenger);
    }
}
