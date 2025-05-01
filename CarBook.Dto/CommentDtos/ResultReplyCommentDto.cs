using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CommentDtos
{
    public class ResultReplyCommentDto
    {
            public int CommentID { get; set; }
            public string Name { get; set; }
            public DateTime CreatedDate { get; set; }
            public string Description { get; set; }
            public int BlogID { get; set; }
            public int ParentCommentId { get; set; }
            public int ReplyCount { get; set; }
           
    }
}

