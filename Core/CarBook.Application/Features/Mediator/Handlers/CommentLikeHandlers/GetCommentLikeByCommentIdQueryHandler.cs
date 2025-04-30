using CarBook.Application.Features.Mediator.Queries.CommentLikeQueries;
using CarBook.Application.Features.Mediator.Results.CommentLikeResults;
using CarBook.Application.Interfaces.CommentLikeInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentLikeHandlers
{
    public class GetCommentLikeByCommentIdQueryHandler : IRequestHandler<GetCommentLikeByCommentIdQuery, GetCommentLikeByCommentIdQueryResult>
    {

        private readonly ICommentLikeRepository _commentLikeRepository;

        public GetCommentLikeByCommentIdQueryHandler(ICommentLikeRepository CommentLikeRepository)
        {
            _commentLikeRepository = CommentLikeRepository;
        }

        public async Task<GetCommentLikeByCommentIdQueryResult> Handle(GetCommentLikeByCommentIdQuery request, CancellationToken cancellationToken)
        {
            return new GetCommentLikeByCommentIdQueryResult
            {

                LikeCount = _commentLikeRepository.GetLikeCountByCommentId(request.CommentID),
                DislikeCount = _commentLikeRepository.GetDislikeCountByCommentId(request.CommentID),
                UserVote = _commentLikeRepository.GetUserLikeStatus(request.CommentID, request.AppUserID),
                CommentID = request.CommentID,

            };
        }
    }
}
