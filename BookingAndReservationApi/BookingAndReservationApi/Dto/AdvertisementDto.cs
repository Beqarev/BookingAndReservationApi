using BookingAndReservationApi.Models;

namespace BookingAndReservationApi.Dto;

public class AdvertisementDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime ReleaseDate { get; set; }
    public User User { get; set; }
}