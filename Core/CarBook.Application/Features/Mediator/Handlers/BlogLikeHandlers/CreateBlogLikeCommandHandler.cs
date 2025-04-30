using CarBook.Application.Features.Mediator.Commands.BlogLikeCommands;
using CarBook.Application.Interfaces.BlogLikeInterfaces;
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

        public Task Handle(CreateBlogLikeCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
