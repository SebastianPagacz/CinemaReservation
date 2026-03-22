using CinemaReservation.Application.CQRS.Commands.ShowCommands;
using CinemaReservation.Application.CQRS.Queries.ShowQueries;
using CinemaReservation.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShowController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await mediator.Send(new GetShowsQuery());

        return StatusCode(result.StatusCode, result.Content);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetShowByIdQuery(id));

        return StatusCode(result.StatusCode, result.Content);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateShowRequest request)
    {
        var result = await mediator.Send(new CreateShowCommand(request.Title, request.ShowDate, request.ShowLength, request.HallId));

        return StatusCode(result.StatusCode, result.Content);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await mediator.Send(new DeleteShowCommand(id));

        return StatusCode(result.StatusCode, result.Content);
    }
}
