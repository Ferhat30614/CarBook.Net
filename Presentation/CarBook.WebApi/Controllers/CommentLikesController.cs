using CarBook.Application.Features.Mediator.Commands.CommentLikeCommands;
using CarBook.Application.Features.Mediator.Queries.CommentLikeQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentLikesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentLikesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentLikeByCommentId(int id, int AppUserId)
        {
            var values = await _mediator.Send(new GetCommentLikeByCommentIdQuery(id, AppUserId));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommentLike(CreateCommentLikeCommand createCommentLikeCommand)
        {
            await _mediator.Send(createCommentLikeCommand);
            return Ok("CommentLike Başarılıyla ekledi");
        }

    }
}
