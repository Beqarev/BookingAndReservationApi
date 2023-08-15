using BookingAndReservationApi.Models;

namespace BookingAndReservationApi.Dto;

public class BookingDto 
{
    public int Id { get; set; }
    public virtual User? User { get; set; }
    public Advertisement Advertisement { get; set; }
    public DateTime BookDate { get; set; }
    public DateTime StartBookingDate { get; set; }
    public DateTime EndBookingDate { get; set; }
}