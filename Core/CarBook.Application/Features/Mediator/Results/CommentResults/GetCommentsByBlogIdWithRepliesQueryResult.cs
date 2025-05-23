﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CommentResults
{
    public class GetCommentsByBlogIdWithRepliesQueryResult
    {
        public int CommentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<GetCommentsByBlogIdWithRepliesQueryResult> Replies { get; set; }
    }
}
