using Business.Dtos.User;
using Business.Interfaces;
using Dal.Entities;
using Error;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web_api.Controllers;

[ApiController, Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService) { _userService = userService; }

    [HttpPost, Authorize(Roles = "admin")]
    public async Task<ActionResult<UserReadDto>> Create(UserCreateDto dto)
    {
        try
        {
            var result = await _userService.Create(dto);
            return Created($"api/user/{result.Id}", result);
        }
        catch (ValidationException e) { return BadRequest(new { e.Message }); }
        catch (ConflictException<AppUser> e) { return Conflict(new { e.Message }); }
    }

    [HttpGet, Authorize(Roles = "admin")]
    public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll()
    {
        return Ok(await _userService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserReadDto?>> GetOneById(string id)
    {
        try
        {
            var result = await _userService.GetOneById(id);
            return Ok(result);
        }
        catch (NotFoundException<AppUser> e) { return NotFound(new { e.Message }); }
    }
}
