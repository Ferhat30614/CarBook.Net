using CarBook.Application.Features.Mediator.Handlers.MessageHandlers;
using CarBook.Application.Features.Mediator.Results.MessageResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.MessageQueries
{
    public class GetMessageByCurrentUserIdQuery:IRequest<List<GetMessageByCurrentUserIdQueryResult>>
    {
        public int CurrentUserID { get; set; }

        public GetMessageByCurrentUserIdQuery(int currentUserID)
        {
            CurrentUserID = currentUserID;
        }
    }
}
