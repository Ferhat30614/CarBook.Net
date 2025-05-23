﻿using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment> where T : class
    {
        private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            var values=_context.Comments.ToList();
             return values.Select(x => new Comment
            {
                CommentID = x.CommentID,
                Name = x.Name,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                BlogID = x.BlogID,
                ParentCommentId=x.ParentCommentId,
                ReplyCount = x.ReplyCount,  



             }).ToList();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.Find(id);
        }

        public List<Comment> GetDirectCommentsByBlogId(int id)
        {
           return _context.Set<Comment>().Where(x=>x.BlogID==id && x.ParentCommentId==null).ToList();
        }

        public int GetCountCommentByBlog(int id)
        {
           return _context.Comments.Where(x=>x.BlogID == id).Count();
        }

        public void Remove(Comment entity)
        {
            _context.Comments.Remove(entity);
            _context.SaveChanges();

        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);
            _context.SaveChanges();

        }

        public int GetCountReplyByComment(int id)
        {
            return _context.Comments.Where(x => x.ParentCommentId == id).Count();
        }

        public List<Comment> GetReplyCommentsByCommentId(int id)
        {
             return _context.Set<Comment>().Where(x=> x.ParentCommentId==id).ToList();
        }
    }

}


