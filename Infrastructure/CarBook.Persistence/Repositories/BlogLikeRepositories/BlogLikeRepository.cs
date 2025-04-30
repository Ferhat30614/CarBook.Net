using CarBook.Application.Interfaces.BlogLikeInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BlogLikeRepositories
{
    public class BlogLikeRepository : IBlogLikeRepository
    {
        private readonly CarBookContext _context;

        public BlogLikeRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetDislikeCountByBlogId(int BlogId)
        {
            return _context.BlogLikes.Where(a => a.BlogID == BlogId && a.IsLike == false).Count();
        }

        public int GetLikeCountByBlogId(int BlogId)
        {
            return _context.BlogLikes.Where(a=>a.BlogID==BlogId && a.IsLike==true).Count();                
        }

        public bool? GetUserLikeStatus(int BlogId, int AppUserId)
        {
            var values = _context.BlogLikes.Where(a => a.BlogID == BlogId && a.AppUserID == AppUserId).FirstOrDefault(); 

            return values?.IsLike;   
        }

        public void CreateBlogLike(BlogLike blogLike)
        {
            _context.BlogLikes.Add(blogLike);   
            _context.SaveChanges();     
        }
    }
}
