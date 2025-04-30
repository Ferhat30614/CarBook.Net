using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CommentLikeCommands
{
    public class CreateCommentLikeCommand:IRequest
    {
        public int AppUserID { get; set; }
        public int CommentID { get; set; }
        public bool IsLike { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
