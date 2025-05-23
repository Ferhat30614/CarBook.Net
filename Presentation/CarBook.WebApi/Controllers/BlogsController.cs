﻿using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var values =  await _mediator.Send(new GetBlogQuery());
            return Ok(values);

        }

        [HttpGet("GetLast3BlogsWithAuthorsList")]
        public async Task<IActionResult> GetLast3BlogsWithAuthorsList()
        {
            var values = await _mediator.Send(new GetLast3BlogsWithAuthorsQuery());
            return Ok(values);

        } 
        
        [HttpGet("GetAllBlogsWithAuthorsList")]
        public async Task<IActionResult> GetAllBlogsWithAuthorsList()
        {
            var values = await _mediator.Send(new GetAllBlogsWithAuthorsQuery());
            return Ok(values);

        }
        
        
        [HttpGet("GetBlogByAuthorId")]
        public async Task<IActionResult> GetBlogByAuthorId(int id)
        {
            var values = await _mediator.Send(new GetBlogByAuthorIdQuery(id));
            return Ok(values);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var values = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog güncellendi");
        }

    }
}
