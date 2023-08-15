using AutoMapper;
using BookingAndReservationApi.Dto;
using BookingAndReservationApi.Interfaces;
using BookingAndReservationApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingAndReservationApi.Controllers;

public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserController(IUserRepository userRepository, IMapper mapper )
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        var users = await _userRepository.GetAll();
        var usersMap = _mapper.Map<UserDto>(users);
        return Ok(usersMap);
    }
}