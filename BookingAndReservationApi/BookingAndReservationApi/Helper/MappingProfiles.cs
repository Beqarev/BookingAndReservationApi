using AutoMapper;
using BookingAndReservationApi.Dto;
using BookingAndReservationApi.Models;

namespace BookingAndReservationApi.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AdvertisementDto, Advertisement>();
        CreateMap<Advertisement, AdvertisementDto>();
        CreateMap<BookingDto, Booking>();
        CreateMap<Booking, BookingDto>();
        CreateMap<Review, ReviewDto>();
        CreateMap<ReviewDto, Review>();
    }
}