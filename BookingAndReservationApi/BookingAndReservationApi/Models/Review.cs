using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingAndReservationApi.Models;

public class Review
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    [ForeignKey("ReviewerUserId")]
    public virtual User? User { get; set; }
    public int Rating { get; set; }
}