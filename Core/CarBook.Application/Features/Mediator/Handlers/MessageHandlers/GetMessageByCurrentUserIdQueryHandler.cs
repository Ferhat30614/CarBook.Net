using CarBook.Application.Features.Mediator.Queries.MessageQueries;
using CarBook.Application.Features.Mediator.Results.MessageResults;
using CarBook.Application.Interfaces.MessageInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.MessageHandlers
{
    public class GetMessageByCurrentUserIdQueryHandler : IRequestHandler<GetMessageByCurrentUserIdQuery, List<GetMessageByCurrentUserIdQueryResult>>
    {
        private readonly IMessageRepository _messageRepository;

        public GetMessageByCurrentUserIdQueryHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<List<GetMessageByCurrentUserIdQueryResult>> Handle(GetMessageByCurrentUserIdQuery request, CancellationToken cancellationToken)
        {
            return _messageRepository.GetMessageByCurrentUser(request.CurrentUserID).Select(a=> new GetMessageByCurrentUserIdQueryResult
            {
                MessageID = a.MessageID,        
                CurrentUserID= request.CurrentUserID,   
                OtherUserID= (request.CurrentUserID== a.SenderID) ? a.ReceiverID : a.SenderID,
                OtherUserName= (request.CurrentUserID == a.SenderID) ? a.Receiver.Name : a.Sender.Name,


            }).ToList();    
        }
    }
}
