using CarBook.Application.Features.Mediator.Commands.CommentLikeCommands;
using CarBook.Application.Interfaces.CommentLikeInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentLikeHandlers
{
    public class CreateCommentLikeCommandHandler : IRequestHandler<CreateCommentLikeCommand>
    {
        private readonly ICommentLikeRepository _commentLikeRepository;

        public CreateCommentLikeCommandHandler(ICommentLikeRepository commentLikeRepository)
        {
            _commentLikeRepository = commentLikeRepository;
        }

        public async Task Handle(CreateCommentLikeCommand request, CancellationToken cancellationToken)
        {
            var value = _commentLikeRepository.GetCommentLikeByFilter(request.CommentID, request.AppUserID);
            if (value == null)
            {

                _commentLikeRepository.CreateCommentLike(new CommentLike
                {
                    AppUserID = request.AppUserID,
                    CommentID = request.CommentID,
                    IsLike = request.IsLike,
                    CreateDate = DateTime.Now
                });

            }
            else
            {
                if (value.IsLike == request.IsLike)
                {
                    _commentLikeRepository.RemoveCommentLike(value);

                }
                else
                {
                    value.IsLike = request.IsLike;
                    value.CreateDate = DateTime.Now;
                    _commentLikeRepository.UpdateCommentLike(value);
                }

            }

        }
    }
}
