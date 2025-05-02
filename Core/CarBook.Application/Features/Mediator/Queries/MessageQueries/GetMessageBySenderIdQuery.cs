using CarBook.Application.Features.Mediator.Results.MessageResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.MessageQueries
{
    public class GetMessageBySenderIdQuery:IRequest<List<GetMessageBySenderIdQueryResult>>
    {
        public int  SenderId { get; set; }
        public int  ReceiverId { get; set; }

        public GetMessageBySenderIdQuery(int senderId, int receiverId)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
        }
    }
}
