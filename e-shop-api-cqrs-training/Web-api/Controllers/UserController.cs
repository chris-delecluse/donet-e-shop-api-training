using Business.Dtos.User;
using Business.Interfaces;
using Dal.Entities;
using Error;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Web_api.Controllers;

[ApiController, Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService) { _userService = userService; }

    [HttpPost]
    public async Task<ActionResult<UserReadDto>> Create(UserCreateDto dto)
    {
        try
        {
            var result = await _userService.Create(dto);
            return Created("", result);
        }
        catch (ValidationException e) { return BadRequest(new { e.Message }); }
        catch (ConflictException<AppUser> e) { return Conflict(new { e.Message }); }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll()
    {
        var result = await _userService.GetAll();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserReadDto?>> GetOneById(string id)
    {
        var result = await _userService.GetOne(id);

        return Ok(result);
    }
}
