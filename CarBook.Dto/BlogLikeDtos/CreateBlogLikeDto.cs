using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.BlogLikeDtos
{
    public class CreateBlogLikeDto
    {
        public int AppUserID { get; set; }
        public int BlogID { get; set; }
        public bool IsLike { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
