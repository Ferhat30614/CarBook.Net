﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } 
        public string Surname { get; set; }
        public string Email { get; set; } 
        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; } = null!;
        public List<BlogLike> BlogLikes { get; set; }
        public List<CommentLike> CommentLikes { get; set; }
        public List<Message> SentMessages { get; set; }
        public List<Message> ReceivedMessages { get; set; }
    }
}
