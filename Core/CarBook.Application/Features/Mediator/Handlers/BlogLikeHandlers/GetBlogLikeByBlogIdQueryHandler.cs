using CarBook.Application.Features.Mediator.Queries.BlogLikeQueries;
using CarBook.Application.Features.Mediator.Results.BlogLikeResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogLikeHandlers
{
    public class GetBlogLikeByBlogIdQueryHandler : IRequestHandler<GetBlogLikeByBlogIdQuery, GetBlogLikeByBlogIdQueryResult>
    {




        public Task<GetBlogLikeByBlogIdQueryResult> Handle(GetBlogLikeByBlogIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
