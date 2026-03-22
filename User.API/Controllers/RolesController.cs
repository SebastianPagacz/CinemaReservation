using Microsoft.AspNetCore.Mvc;
using User.Domain.Repository;

namespace User.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController(IRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var result = await repository.GetRolesAsync();

        return StatusCode(200, result);
    }
}
