using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class CommentLike
    {
        public int CommentLikeID { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        public int CommentID { get; set; }
        public Comment Comment  { get; set; }
        public bool IsLike { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
