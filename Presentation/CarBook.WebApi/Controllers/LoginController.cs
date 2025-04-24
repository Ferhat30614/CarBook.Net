using CarBook.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook.Application.Features.Mediator.Results.AppUserResults;
using CarBook.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Index(GetCheckAppUserQuery query)
        {
            var value = await _mediator.Send(query);
            if (value.IsExist)
            {
                return Created("", JwtTokenGenerator.GenerateToken(value));
            }
            else
            {
                return BadRequest("Kullanıcı adı veya hatalı anam ");
            }
            
        }
    }
}
