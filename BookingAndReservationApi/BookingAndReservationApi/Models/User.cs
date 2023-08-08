namespace BookingAndReservationApi.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<Advertisement> Advertisements { get; set; }
}