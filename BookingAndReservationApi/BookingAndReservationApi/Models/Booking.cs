namespace BookingAndReservationApi.Models;

public class Booking
{
    public int Id { get; set; }
    public User User { get; set; }
    public Advertisement Advertisement { get; set; }
    public DateTime BookDate { get; set; }
    public DateTime StartBookingDate { get; set; }
    public DateTime EndBookingDate { get; set; }
}