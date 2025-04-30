using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.Mediator.Commands.BlogLikeCommands;
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
    public class CreateBlogLikeCommandHandler : IRequestHandler<CreateBlogLikeCommand>
    {
        private readonly IBlogLikeRepository _blogLikeRepository;

        public CreateBlogLikeCommandHandler(IBlogLikeRepository blogLikeRepository)
        {
            _blogLikeRepository = blogLikeRepository;
        }

        public async Task Handle(CreateBlogLikeCommand request, CancellationToken cancellationToken)
        {
            var value = _blogLikeRepository.GetBlogLikeByFilter(request.BlogID, request.AppUserID);
            if (value == null) {

                _blogLikeRepository.CreateBlogLike(new BlogLike
                {
                    AppUserID = request.AppUserID,
                    BlogID = request.BlogID,
                    IsLike = request.IsLike,
                    CreateDate = DateTime.Now
                });

            }
            else
            {
                if (value.IsLike == request.IsLike)
                {
                    _blogLikeRepository.RemoveBlogLike(value);
                    
                }
                else
                {
                    value.IsLike = request.IsLike;
                    value.CreateDate = DateTime.Now;
                    _blogLikeRepository.UpdateBlogLike(value);
                }

            }
            
        }
    }
}
