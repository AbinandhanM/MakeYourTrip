using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelPackage.Models.Context;
using TravelPackage.Interfaces;
using TravelPackage.Models;
using System.Threading.Channels;

namespace TourPackage.Models
{
    public class TourDetailsRepo : IRepo<TourDetails, int>
    {
        private readonly TourContext _context;

        public TourDetailsRepo(TourContext context)
        {
            _context = context;
        }

        public async Task<ICollection<TourDetails?>> GetAll()
        {
            if (_context.TourDetails != null)
            {

                var tourdetails = await _context.TourDetails.Include(u => u.TourInclusion).Include(s => s.TourExclusion).Include(t => t.TourDate).Include(t => t.TourDestination).ToListAsync();
                return tourdetails;

            }
            else
            {
                return null;
            }
        }



        public async Task<TourDetails?> Get(int id)
        {
            return await _context.TourDetails
                .Include(u => u.TourInclusion)
                .Include(s => s.TourExclusion)
                .Include(t => t.TourDate)
                .Include(t => t.TourDestination)
                .FirstOrDefaultAsync(s => s.TourId == id);
        }

        public async Task<TourDetails> Add(TourDetails tourDetails)
        {
            _context.TourDetails.Add(tourDetails);
            await _context.SaveChangesAsync();
            return tourDetails;
        }

        public async Task<TourDetails> Update(TourDetails updatedtourDetails)
        {

            var tourdetails = await Get(updatedtourDetails.TourId);
            if (tourdetails != null)
            {
                tourdetails.TourName = updatedtourDetails.TourName;
                tourdetails.TourDescription = updatedtourDetails.TourDescription;
                tourdetails.TourPrice = updatedtourDetails.TourPrice;
                tourdetails.maxCapacity = updatedtourDetails.maxCapacity;
                tourdetails.BookedCapacity = updatedtourDetails.BookedCapacity;
                tourdetails.Availability = updatedtourDetails.Availability;


            }

            await _context.SaveChangesAsync();
            return tourdetails;
        }

        public async Task<TourDetails> Delete(int id)
        {
            var tourDetails = await _context.TourDetails.FirstOrDefaultAsync(u => u.TourId == id);
            if (tourDetails == null)
            {
                throw new Exception("There is no data with particular tour Id");
            }

            _context.TourDetails.Remove(tourDetails);
            await _context.SaveChangesAsync();
            return tourDetails;
        }

        public Task<BookingCountUpdateDTO?> ChangeBookingStatus(BookingCountUpdateDTO bookingCountUpdate)
        {
            var tourId = bookingCountUpdate.tourId;
            var bookedCapacity = bookingCountUpdate.bookedCapacity;

            // Retrieve the Tour entity from the database
            var tour = _context.TourDetails.FirstOrDefault(t => t.TourId == tourId);

            if (tour == null)
            {
                throw new ArgumentException("Tour not found.");
            }

            // Update the bookedCapacity of the retrieved Tour entity
            tour.BookedCapacity = bookedCapacity;

            // Save the changes to the database
            _context.SaveChanges();

            // Return the updated BookingCountUpdateDTO
            return Task.FromResult(bookingCountUpdate);
        }


    }




        }
    

