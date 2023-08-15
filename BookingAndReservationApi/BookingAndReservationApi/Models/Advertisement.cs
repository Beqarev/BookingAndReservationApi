using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingAndReservationApi.Models;

public class Advertisement
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    [ForeignKey("AdvertisementUserId")]
    public virtual User? User { get; set; }

    public DateTime ReleaseDate { get; set; }
    public ICollection<Review> Reviews { get; set; }
}