using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.BlogLikeDtos
{
    public class ResultBlogLikeDto
    {
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public int BlogID { get; set; }
        public int UserID { get; set; }
        public bool? UserVote { get; set; }

    }
}
