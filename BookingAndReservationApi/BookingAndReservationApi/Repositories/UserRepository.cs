using BookingAndReservationApi.Data;
using BookingAndReservationApi.Interfaces;
using BookingAndReservationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingAndReservationApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<List<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> Get(int Id)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);
    }

    public async Task<User> Add(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> Update(int Id, User request)
    {
        var user = await _context.Users.FindAsync(Id);
        user.Id = request.Id;
        user.Email = request.Email;
        user.Password = request.Password;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;

        await _context.SaveChangesAsync();
        return user;
    }

    public bool Delete(int Id)
    {
        _context.Remove(Id);
        return true;
    }
}