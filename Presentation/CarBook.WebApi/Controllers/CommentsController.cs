using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistence.Repositories;
using CarBook.Persistence.Repositories.CommentRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;

        public CommentsController(IGenericRepository<Comment> repository)
        {
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

        [HttpGet("GetCommentsByBlog")]
        public IActionResult GetCommentsByBlog(int id)
        {
            var values = _repository.GetCommentsByBlogId(id);   
            return Ok(values);
        }


    }
}
