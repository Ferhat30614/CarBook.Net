﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
    public class GetLast3BlogsWithAuthorsQueryResult
    {
        public int BlogID { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
        public int CommentCount { get; set; }

        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string CoverImage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
