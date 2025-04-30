using CarBook.Application.Features.Mediator.Results.CommentLikeResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CommentLikeQueries
{
    public class GetCommentLikeByCommentIdQuery:IRequest<GetCommentLikeByCommentIdQueryResult>
    {
        public int CommentID { get; set; }
        public int AppUserID { get; set; }

        public GetCommentLikeByCommentIdQuery(int commentID, int appUserID)
        {
            CommentID = commentID;
            AppUserID = appUserID;
        }
    }
}
