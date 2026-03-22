using CinemaReservation.Application.CQRS.Commands.CinemaHallCommands;
using CinemaReservation.Application.CQRS.Queries.CinemaHallQueries;
using CinemaReservation.Application.CQRS.Queries.HallSeatQueries;
using CinemaReservation.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CinemaHallController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(CreateHallRequest request)
    {
        var resposne = await mediator.Send(new CreateHallCommand(request.Name,request.Dimensions));

        return StatusCode(resposne.StatusCode, resposne.Content);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var resposne = await mediator.Send(new GetHallsQuery());

        return StatusCode(resposne.StatusCode, resposne.Content);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await mediator.Send(new GetHallByIdQuery(id));

        return StatusCode(response.StatusCode, response.Content);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await mediator.Send(new DeleteHallCommand(id));

        return StatusCode(response.StatusCode);
    }

    [HttpGet("/seats/{hallId}")]
    public async Task<IActionResult> GetHallSeats(int hallId)
    {
        var response = await mediator.Send(new GetHallSeatsQuery(hallId));

        return StatusCode(response.StatusCode, response.Content);
    }
}
