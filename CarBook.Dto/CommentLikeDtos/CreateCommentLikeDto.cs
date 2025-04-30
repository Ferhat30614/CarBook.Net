using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CommentLikeDtos
{
    public class CreateCommentLikeDto
    {
        public int AppUserID { get; set; }
        public int CommentID { get; set; }
        public bool IsLike { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
