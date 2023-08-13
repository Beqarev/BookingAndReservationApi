using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookingAndReservationApi.Models;

public class Booking
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("BookingUserId")]
    public virtual User? User { get; set; }
    public Advertisement Advertisement { get; set; }
    public DateTime BookDate { get; set; }
    public DateTime StartBookingDate { get; set; }
    public DateTime EndBookingDate { get; set; }
}