using AutoMapper;
using BookingAndReservationApi.Dto;
using BookingAndReservationApi.Interfaces;
using BookingAndReservationApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingAndReservationApi.Controllers;
[Route("api/advertisement")]
[ApiController]
public class AdvertisementController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAdvertisementRepository _advertisementRepository;

    public AdvertisementController(IAdvertisementRepository advertisementRepository, IMapper mapper)
    {
        _mapper = mapper;
        _advertisementRepository = advertisementRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<AdvertisementDto>>> GetAllAdvertisements()
    {
        var advertisements = _mapper.Map<AdvertisementDto>(await _advertisementRepository.GetAll());
        return Ok(advertisements);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AdvertisementDto>> GetAdvertisement(int id)
    {
        var result = _mapper.Map<AdvertisementDto>(await _advertisementRepository.Get(id));
        return Ok(result);
    }

    [HttpGet("{advertisementId}/rating")]
    public ActionResult<double> GetAdvertisementRating(int advertisementId)
    {
        var rating = _advertisementRepository.GetAdvertisementRating(advertisementId);

        return Ok(rating);
    }

    [HttpPost]
    public async Task<ActionResult<Advertisement>> AddAdvertisement([FromBody] AdvertisementDto advertisementDto)
    {
        var advertisement = _mapper.Map<Advertisement>(advertisementDto);
        var result = await _advertisementRepository.Add(advertisement);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Advertisement>> UpdateAdvertisement(int id,
        [FromBody] AdvertisementDto advertisementDto)
    {
        var advertisement = _mapper.Map<Advertisement>(advertisementDto);
        var result = await _advertisementRepository.Update(id, advertisement);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public ActionResult<bool> DeleteAdvertisement(int id)
    {
        _advertisementRepository.Delete(id);
        return true;
    }

}