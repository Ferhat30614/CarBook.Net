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
    }
}
