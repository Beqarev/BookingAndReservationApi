using BookingAndReservationApi.Models;

namespace BookingAndReservationApi.Interfaces;

public interface IAdvertisementRepository : IRepository<Advertisement>
{
    decimal GetAdvertisementRating(int advertisementId);
}