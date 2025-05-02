using CarBook.Application.Features.Mediator.Commands.MessageCommands;
using CarBook.Application.Features.Mediator.Queries.MessageQueries;
using CarBook.Application.Features.Mediator.Results.MessageResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageCommand createMessageCommand) { 

            _mediator.Send(createMessageCommand);     
            return Ok("Başarıyla Mesaj eklendi");         
        
        }
        
        [HttpGet]
        public async Task<IActionResult> GetMessageBySenderId(int senderId,int receiverId) { 

            var value= await _mediator.Send(new GetMessageBySenderIdQuery(senderId,receiverId));     
            return Ok(value);         
        
        }
        [HttpGet ("GetMessageByCurrentUser")]
        public async Task<IActionResult> GetMessageByCurrentUser(int currentUserId) { 

            var value= await _mediator.Send(new GetMessageByCurrentUserIdQuery(currentUserId));     
            return Ok(value);         
        
        }
    }
}
