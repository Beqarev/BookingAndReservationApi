namespace BookingAndReservationApi.Models;

public class Advertisement
{
    public int Id { get; set; }
    public string AdvertisementTitle { get; set; }
    public string AdvertisementText { get; set; }
    public User User { get; set; }
    
}