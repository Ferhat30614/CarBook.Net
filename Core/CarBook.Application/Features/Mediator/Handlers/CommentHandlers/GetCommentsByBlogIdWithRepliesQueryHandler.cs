using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
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
    public class GetCommentsByBlogIdWithRepliesQueryHandler : IRequestHandler<GetCommentsByBlogIdWithRepliesQuery,List<GetCommentsByBlogIdWithRepliesQueryResult>>
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public GetCommentsByBlogIdWithRepliesQueryHandler(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<GetCommentsByBlogIdWithRepliesQueryResult>> Handle(GetCommentsByBlogIdWithRepliesQuery request, CancellationToken cancellationToken)
        {

            var directComments=_commentRepository.GetDirectCommentsByBlogId(request.BlogId);

            var result = directComments.Select(Comment => MapCommentWithReplies(Comment)).ToList(); 

            return result;  
        }

        private GetCommentsByBlogIdWithRepliesQueryResult MapCommentWithReplies(Comment comment)
        {
            return new GetCommentsByBlogIdWithRepliesQueryResult
            {
                CommentID = comment.CommentID,
                Name = comment.Name,
                Description = comment.Description,
                CreatedDate = comment.CreatedDate,
                Replies = _commentRepository.GetReplyCommentsByCommentId(comment.CommentID)
                .Select(reply => MapCommentWithReplies(reply))
                .ToList()

            };

        }

    }
}
