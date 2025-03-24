using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarPricingWithCarList()
        {
            var values = await _mediator.Send(new GetCarPricingWithCarQuery());
            return Ok(values);
        }

        [HttpGet("CarPricingWithTimePeriodList")]
        public async Task<IActionResult> CarPricingWithTimePeriodList()
        {
            var values = await _mediator.Send(new GetCarPricingWithTimePeriodQuery());
            return Ok(values);

        }
    }
}
