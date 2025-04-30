using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CommentLikeResults
{
    public class GetCommentLikeByCommentIdQueryResult
    {
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public int CommentID { get; set; }
        public bool? UserVote { get; set; }
    }
}
