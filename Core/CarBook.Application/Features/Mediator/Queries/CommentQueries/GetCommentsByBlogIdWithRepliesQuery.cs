using CarBook.Application.Features.Mediator.Results.CommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentsByBlogIdWithRepliesQuery:IRequest<List<GetCommentsByBlogIdWithRepliesQueryResult>>
    {
        public int BlogId { get; set; }

        public GetCommentsByBlogIdWithRepliesQuery(int blogId)
        {
            BlogId = blogId;
        }
    }
}
