using Business.Dtos.Auth;
using Business.Dtos.User;
using Business.Interfaces;
using Dal.Entities;
using Error;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Web_api.Controllers;

[ApiController, Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) { _authService = authService; }

    [HttpPost("local/login")]
    public async Task<ActionResult<SignInResponseDto>> SignIn(SignInRequestDto dto)
    {
        try
        {
            var result = await _authService.Authenticate(dto);
            return Ok(result);
        }
        catch (Exception e) { return Unauthorized(new { e.Message }); }
    }

    [HttpPost("local/register")]
    public async Task<ActionResult<UserReadDto>> Register(UserCreateDto dto)
    {
        try
        {
            var result = await _authService.Register(dto);
            return Created($"api/user/{result.Id}", result);
        }
        catch (ValidationException e) { return BadRequest(new { e.Message }); }
        catch (ConflictException<AppUser> e) { return Conflict(new { e.Message }); }
    }
}
