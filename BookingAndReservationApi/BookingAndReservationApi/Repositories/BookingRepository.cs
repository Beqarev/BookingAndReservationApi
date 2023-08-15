using BookingAndReservationApi.Data;
using BookingAndReservationApi.Interfaces;
using BookingAndReservationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingAndReservationApi.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly DataContext _context;

    public BookingRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<List<Booking>> GetAll()
    {
        return await _context.Bookings
            .Include(x => x.User)
            .Include(x => x.Advertisement)
            .ToListAsync();
    }

    public async Task<Booking> Get(int id)
    {
        var booking = await _context.Bookings
            .Include(x => x.User)
            .Include(x => x.Advertisement)
            .FirstOrDefaultAsync(x => x.Id == id);
        return booking;
    }

    public async Task<Booking> Add(Booking booking)
    {
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
        return booking;
    }

    public async Task<Booking> Update(int id, Booking request)
    {
        var booking = await _context.Bookings.FindAsync(id);
        booking.Id = request.Id;
        booking.Advertisement = request.Advertisement;
        booking.User = request.User;
        booking.BookDate = request.BookDate;
        booking.StartBookingDate = request.StartBookingDate;
        booking.EndBookingDate = request.EndBookingDate;

        await _context.SaveChangesAsync();
        return booking;
    }

    public bool Delete(int id)
    {
        var booking = _context.Bookings.Find(id);
        if (booking is null)
            return false;
        
        _context.Bookings.Remove(booking);
        _context.SaveChanges();
        return true;
    }
}