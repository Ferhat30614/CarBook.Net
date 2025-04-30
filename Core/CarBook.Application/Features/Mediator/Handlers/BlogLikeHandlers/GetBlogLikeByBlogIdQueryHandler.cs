using CarBook.Application.Features.Mediator.Queries.BlogLikeQueries;
using CarBook.Application.Features.Mediator.Results.BlogLikeResults;
using CarBook.Application.Interfaces.BlogLikeInterfaces;
using CarBook.Domain.Entities;
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

        private readonly IBlogLikeRepository _blogLikeRepository;

        public GetBlogLikeByBlogIdQueryHandler(IBlogLikeRepository blogLikeRepository)
        {
            _blogLikeRepository = blogLikeRepository;
        }

        public async Task<GetBlogLikeByBlogIdQueryResult> Handle(GetBlogLikeByBlogIdQuery request, CancellationToken cancellationToken)
        {
            return new GetBlogLikeByBlogIdQueryResult
            {

                LikeCount = _blogLikeRepository.GetLikeCountByBlogId(request.BlogID),
                DislikeCount = _blogLikeRepository.GetDislikeCountByBlogId(request.BlogID),
                UserVote = _blogLikeRepository.GetUserLikeStatus(request.BlogID,request.AppUserID),
                BlogID=request.BlogID,

            };
        }
    }
}
