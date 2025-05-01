using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int BlogID { get; set; }
        public Blog Blog { get; set; }
        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
        public int ReplyCount { get; set; }

        public List<CommentLike> CommentLikes { get; set; }
    }
}
