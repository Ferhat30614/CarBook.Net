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


            // _commentRepository.GetDirectCommentsByBlogId(request.BlogId).Select(a=> new GetCommentsByBlogIdWithRepliesQueryResult
            //{
            //    CommentID = a.CommentID,    
            //    Name = a.Name,  
            //    Description = a.Description,    
            //    CreatedDate = a.CreatedDate,    
            //    Replies =  _commentRepository.GetReplyCommentsByCommentId(a.CommentID).Select(b=> new GetCommentsByBlogIdWithRepliesQueryResult
            //    {
            //        CommentID = b.CommentID,
            //        Name = b.Name,
            //        Description = b.Description,
            //        CreatedDate = b.CreatedDate,
            //        Replies=new List<GetCommentsByBlogIdWithRepliesQueryResult> ()
            //    }).ToList() 

            //}).ToList();    
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
