using CarBook.Application.Features.Mediator.Results.BlogLikeResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.BlogLikeQueries
{
    public class GetBlogLikeByBlogIdQuery:IRequest<GetBlogLikeByBlogIdQueryResult>
    {
        public int BlogID { get; set; }
        public int AppUserID { get; set; }

        public GetBlogLikeByBlogIdQuery(int blogID, int appUserID)
        {
            BlogID = blogID;
            AppUserID = appUserID;
        }
    }
}
