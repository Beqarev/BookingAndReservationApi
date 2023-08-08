namespace BookingAndReservationApi.Models;

public class Review
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public User User { get; set; }
    public Advertisement Advertisement { get; set; }
    public int Rating { get; set; }
}