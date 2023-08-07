using TravelPackage.Models;

namespace TravelPackage.Interfaces
{
    public interface IRepo<T, K>
    {

        public Task<T?> Add(T item);
        public Task<T?> Delete(K key);
        public Task<T?> Get(K key);
        public Task<T?> Update(T item);
        public Task<ICollection<T>?> GetAll();

        public Task<BookingCountUpdateDTO?> ChangeBookingStatus(BookingCountUpdateDTO bookingCountUpdate);
    }
}
