﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TravelPackage.Models;
using TravelPackage.Models.Context;
using TravelPackage.Interfaces;
using TravelPackage.Exceptions;

public class TourDestinationRepo : IRepo<TourDestination, int>
{
    private readonly TourContext _context;

    public TourDestinationRepo(TourContext context)
    {
        _context = context;
    }

    
    public async Task<TourDestination>Add(TourDestination tourdestination)
    {
        if (tourdestination == null)
        {
            throw new ArgumentNullException("TourDestination must not be null.");
        }

        if (_context.TourDestinations != null)
        {

            _context.TourDestinations.Add(tourdestination);
            _context.SaveChanges();

            return tourdestination;
        }
        else
        {
            throw new DatabaseEmptyException("Database is empty");
        }
    }

  
    public async Task<TourDestination> Get(int id)
    {
        return _context.TourDestinations.FirstOrDefault(td => td.Id == id);
    }
    public async Task<ICollection<TourDestination>> GetAll()
    {
        if (_context.Exclusions != null)
        {
            return await _context.TourDestinations.Include(t=>t.Destination).ToListAsync();
        }
        else
        {
            return new List<TourDestination>();
        }
    }

    public async Task<TourDestination> Update(TourDestination tourdestination)
    {
        var tourDestination = _context.TourDestinations.FirstOrDefault(td => td.Id == tourdestination.Id);

        if (tourDestination == null)
        {
            throw new ArgumentException("TourDestination not found.");
        }
        if (_context.TourDestinations == null)
        {
            tourDestination.DestinationId = tourdestination.DestinationId;
            tourDestination.Destinationimage = tourdestination.Destinationimage;
            tourdestination.DestinationActivity= tourdestination.DestinationActivity;
            _context.SaveChanges();
            return tourDestination;

        }
        else
        {
            throw new Exception("Tour Destination not found");
        }

    }

 
    public async Task<TourDestination> Delete(int id)
    {
        var tourDestination = _context.TourDestinations.FirstOrDefault(td => td.Id == id);

        if (tourDestination == null)
        {
            throw new ArgumentException("TourDestination not found.");
        }

        _context.TourDestinations.Remove(tourDestination);
        _context.SaveChanges();
        return tourDestination;
    }

    public Task<BookingCountUpdateDTO?> ChangeBookingStatus(BookingCountUpdateDTO bookingCountUpdate)
    {
        throw new NotImplementedException();
    }
}
