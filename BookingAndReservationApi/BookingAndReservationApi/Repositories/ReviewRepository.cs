using AutoMapper;
using BookingAndReservationApi.Data;
using BookingAndReservationApi.Interfaces;
using BookingAndReservationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingAndReservationApi.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ReviewRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<Review>> GetAll()
    {
        return await _context.Reviews
            .Include(x => x.User)
            .ToListAsync();
    }

    public async Task<Review> Get(int Id)
    {
        var review = await _context.Reviews
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == Id);
        return review;
    }

    public async Task<Review> Add(Review review)
    {
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
        return review;
    }

    public async Task<Review> Update(int Id, Review request)
    {
        var review = await _context.Reviews.FindAsync(Id);
        review.Id = request.Id;
        review.Rating = request.Rating;
        review.Text = request.Text;
        review.Title = request.Title;
        review.User = request.User;

        await _context.SaveChangesAsync();
        return review;
    }

    public bool Delete(int Id)
    {
        var review = _context.Reviews.Find(Id);
        if (review is null)
            return false;

        _context.Reviews.Remove(review);
        _context.SaveChanges();
        return true;
    }
}