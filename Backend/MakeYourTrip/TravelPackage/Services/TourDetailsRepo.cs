﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourPackage.Models.Context;
using TourPackage.Interfaces;

namespace TourPackage.Models
{
    public class TourDetailsRepo : IRepo<TourDetails,int>
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

                var tourdetails= await _context.TourDetails.Include(u=>u.TourInclusion).Include(s=>s.TourExclusion).Include(t=>t.TourDate).ToListAsync();
                return tourdetails;
                
            }
            else
            {
                return null;
            }
        }



        public async Task<TourDetails?> Get(int id)
        {
            return await _context.TourDetails.FirstOrDefaultAsync(s=>s.TourId==id);
        }
      
        public async Task<TourDetails> Add(TourDetails tourDetails)
        {
            _context.TourDetails.Add(tourDetails);
            await _context.SaveChangesAsync();
            return tourDetails;
        }

        public async Task<TourDetails> Update(TourDetails updatedtourDetails)
        {

            var tourdetails =await  Get(updatedtourDetails.TourId);
            if (tourdetails != null)
            {
                tourdetails.TourName = updatedtourDetails.TourName;
                tourdetails.TourDescription= updatedtourDetails.TourDescription;
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
            var tourDetails = await _context.TourDetails.FirstOrDefaultAsync(u=>u.TourId==id);
            if (tourDetails == null)
            {
                throw new Exception("There is no data with particular tour Id");
            }

            _context.TourDetails.Remove(tourDetails);
            await _context.SaveChangesAsync();
            return tourDetails;
        }


    
    }
}
