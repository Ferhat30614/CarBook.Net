using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistence.Repositories;
using CarBook.Persistence.Repositories.CommentRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        private readonly IGenericRepository<Comment> _repository;

        public CommentsController(IMediator mediator, IGenericRepository<Comment> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult CommentList() 
        {
            var values=_repository.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _repository.GetById(id);
            return Ok(values);      
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _repository.Create(comment);    
            return Ok("yorum başarıyla eklendi..");
        }

        [HttpPost("CreateComment")]
        public  async Task<IActionResult> CreateComment(CreateCommentCommand comment)
        {
             await _mediator.Send(comment);
            return Ok("Yorum Başarıyla eklendi");
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {            
            _repository.Update(comment);
            return Ok("yorum başarıyla güncellendi..");
        }

        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var values = _repository.GetById(id);
            _repository.Remove(values);
            return Ok("yorum başarıyla silindi..");
        }

        [HttpGet("GetDirectCommentsByBlog")]
        public IActionResult GetCommentsByBlog(int id)
        {
            var values = _repository.GetDirectCommentsByBlogId(id);   
            return Ok(values);
        }
        [HttpGet("GetCountCommentByBlog")]
        public IActionResult GetCountCommentByBlog(int id)
        {
            var values = _repository.GetCountCommentByBlog(id);   
            return Ok(values);
        }


    }
}
