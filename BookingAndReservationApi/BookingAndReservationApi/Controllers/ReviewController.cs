using AutoMapper;
using BookingAndReservationApi.Dto;
using BookingAndReservationApi.Interfaces;
using BookingAndReservationApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingAndReservationApi.Controllers;
[Route("api/review")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;

    public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<ReviewDto>>> GetAllReviews()
    {
        var reviews = await _reviewRepository.GetAll();
        var reviewMap = _mapper.Map<ReviewDto>(reviews);
        return Ok(reviewMap);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewDto>> GetReview(int id)
    {
        var review = await _reviewRepository.Get(id);
        var reviewMap = _mapper.Map<ReviewDto>(review);
        return Ok(reviewMap);
    }

    [HttpPost]
    public async Task<ActionResult<Review>> AddReview(ReviewDto reviewDto)
    {
        var result = _mapper.Map<Review>(reviewDto);
        await _reviewRepository.Add(result);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Review>> UpdateReview(int id, [FromBody] ReviewDto reviewDto)
    {
        var review = _mapper.Map<Review>(reviewDto);
        var result = await _reviewRepository.Update(id, review);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public ActionResult<bool> DeleteReview(int id)
    {
        _reviewRepository.Delete(id);
        return true;
    }
}
