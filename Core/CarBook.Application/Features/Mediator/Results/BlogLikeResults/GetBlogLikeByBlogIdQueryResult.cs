using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.BlogLikeResults
{
    public class GetBlogLikeByBlogIdQueryResult
    {      

        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public int BlogID { get; set; }
        public bool? UserVote { get; set; }
    }
}
