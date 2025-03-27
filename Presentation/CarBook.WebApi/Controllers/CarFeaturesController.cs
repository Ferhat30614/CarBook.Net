using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarFeatureList(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);

        }
        [HttpGet("CarFeatureAvailableChangeToFalse")]
        public async Task<IActionResult> CarFeatureAvailableChangeToFalse(int id)
        {
            var values =  _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok("Başarıyla güncellendi");

        }

        [HttpGet("CarFeatureAvailableChangeToTrue")]
        public async Task<IActionResult> CarFeatureAvailableChangeToTrue(int id)
        {
            var values = _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok("Başarıyla güncellendi");

        }
    }
}
