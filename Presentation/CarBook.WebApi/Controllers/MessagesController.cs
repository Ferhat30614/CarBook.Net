using CarBook.Application.Features.Mediator.Commands.MessageCommands;
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
    }
}
