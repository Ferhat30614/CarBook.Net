using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> LocationList() 
        {
            var values = await _mediator.Send(new GetLocationQuery());
            return Ok(values);        
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var values = _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            var values = _mediator.Send(command);
            return Ok("Konum eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            var values = _mediator.Send(command);
            return Ok("Konum Güncellendi");
        
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            var values = _mediator.Send(new RemoveLocationCommand(id));
            return Ok("Konum silindi");
        }

    }
}
