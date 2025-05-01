using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentsByBlogIdWithRepliesQueryHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public GetCommentsByBlogIdWithRepliesQueryHandler(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            await _commentRepository.CreateAsync(new Comment
            {
                Name = request.Name,
                CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString()),
                BlogID = request.BlogID,
                Description = request.Description,
                Email = request.Email,
                ParentCommentId = request.ParentCommentId,


            });
        }
    }
}
