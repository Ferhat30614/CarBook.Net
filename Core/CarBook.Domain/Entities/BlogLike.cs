using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class BlogLike
    {
        public int BlogLikeID  { get; set; }
        public int AppUserID  { get; set; }
        public AppUser AppUser { get; set; }
        public int BlogID  { get; set; }
        public Blog Blog { get; set; }
        public bool IsLike  { get; set; }
        public DateTime CreateDate  { get; set; }
       
    }
}
