using CarBook.Application.Features.Mediator.Commands.AppUserCommands;
using CarBook.Application.Features.Mediator.Queries.BlogLikeQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogLikesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogLikesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogLikeByBlogId(int id,int AppUserId)
        {
            var values = await _mediator.Send(new GetBlogLikeByBlogIdQuery(id,AppUserId));
            return Ok(values);
        }


    }
}
