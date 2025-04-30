using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.BlogLikeInterfaces
{
    public interface IBlogLikeRepository
    {
        int GetLikeCountByBlogId(int BlogId); 
        int GetDislikeCountByBlogId(int BlogId); 
        bool? GetUserLikeStatus(int BlogId,int AppUserId); 
        void CreateBlogLike(BlogLike blogLike); 
        void UpdateBlogLike(BlogLike blogLike); 
        void RemoveBlogLike(BlogLike blogLike); 

        BlogLike? GetBlogLikeByFilter(int blogId,int appUserId);   



    }
}
