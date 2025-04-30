using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CommentLikeDtos
{
    public class ResultCommentLikeDto
    {
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public int CommentID { get; set; }
        public bool? UserVote { get; set; }

    }
}
