using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Application.Requests;
using User.Application.Services;
using User.Domain.Models;
using User.Domain.Repository;

namespace User.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IRepository repository, ILoginService loginService) : ControllerBase
{
    [HttpPost("Register")]
    public async Task<IActionResult> RegisterUser(RegisterUserRequest request)
    {
        var result = await loginService.RegisterAsync(request.Email, request.Username, request.Password);

        if (result is true)
            return StatusCode(204);

        return StatusCode(400, new { Header = "Could not handle your request"});
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginUser(LoginRequest request)
    {
        var result = await loginService.LoginAsync(request.Email, request.Password);

        if (result == "Nan")
            return StatusCode(401, "Invalid Email or Password");

        return StatusCode(200, result);
    }

    [Authorize(Policy = "AdminPolicy")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await repository.GetUserByIdAsync(id);

        return StatusCode(200, result);
    }
}
