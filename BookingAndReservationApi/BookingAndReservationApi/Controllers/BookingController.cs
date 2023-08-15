using AutoMapper;
using BookingAndReservationApi.Dto;
using BookingAndReservationApi.Interfaces;
using BookingAndReservationApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingAndReservationApi.Controllers;

[Route("api/booking")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IMapper _mapper;

    public BookingController(IBookingRepository bookingRepository, IMapper mapper)
    {
        _bookingRepository = bookingRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<BookingDto>>> GetAllBookings()
    {
        var bookings = _mapper.Map<BookingDto>(await _bookingRepository.GetAll());
        return Ok(bookings);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<BookingDto>> GetBooking(int id)
    {
        var booking = _mapper.Map<BookingDto>(await _bookingRepository.Get(id));
        return Ok(booking);
    }

    [HttpPost]
    public async Task<ActionResult<Booking>> AddBooking([FromBody] BookingDto bookingDto)
    {
        var booking = _mapper.Map<Booking>(bookingDto);
        var result = await _bookingRepository.Add(booking);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Booking>> UpdateBooking(int id, [FromBody] BookingDto bookingDto)
    {
        var booking = _mapper.Map<Booking>(bookingDto);
        var result = await _bookingRepository.Update(id, booking);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public ActionResult<bool> DeleteBooking(int id)
    {
        _bookingRepository.Delete(id);
        return true;
    }
}