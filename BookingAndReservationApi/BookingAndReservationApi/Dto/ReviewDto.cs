using BookingAndReservationApi.Models;

namespace BookingAndReservationApi.Dto;

public class ReviewDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public User User { get; set; }
    public int Rating { get; set; }
}