using AutoMapper;
using BookingAndReservationApi.Data;
using BookingAndReservationApi.Interfaces;
using BookingAndReservationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingAndReservationApi.Repositories;

public class AdvertisementRepository : IAdvertisementRepository
{
    private readonly DataContext _context;

    public AdvertisementRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<List<Advertisement>> GetAll()
    {
        return await _context.Advertisements
            .Include(x => x.User)
            .Include(x => x.Reviews)
            .ToListAsync();
    }

    public async Task<Advertisement> Get(int id)
    {
        var advertiesement =
            await _context.Advertisements
                .Include(x => x.User)
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync(x => x.Id == id);
        return advertiesement;
    }

    public async Task<Advertisement> Add(Advertisement advertisement)
    {
        _context.Advertisements.Add(advertisement);
        await _context.SaveChangesAsync();
        return advertisement;
    }

    public async Task<Advertisement> Update(int id, Advertisement request)
    {
        var advertisement = await _context.Advertisements.FindAsync(id);
        advertisement.Id = request.Id;
        advertisement.Reviews = request.Reviews;
        advertisement.Text = request.Text;
        advertisement.Title = request.Title;
        advertisement.User = request.User;
        advertisement.ReleaseDate = request.ReleaseDate;

        await _context.SaveChangesAsync();
        return advertisement;
    }

    public bool Delete(int id)
    {
        var advertisement = _context.Advertisements.Find(id);
        if (advertisement is null)
            return false;
            
        _context.Advertisements.Remove(advertisement);
        _context.SaveChanges();
        return true;
    }

    public decimal GetAdvertisementRating(int advertisementId)
    {
        var review = _context.Reviews.Where(a => a.Id == advertisementId);
        return (decimal)review.Sum(r => r.Rating) / review.Count();
    }
}