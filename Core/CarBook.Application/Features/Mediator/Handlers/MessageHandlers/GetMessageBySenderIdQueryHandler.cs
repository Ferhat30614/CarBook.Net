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
    public class GetMessageBySenderIdQueryHandler : IRequestHandler<GetMessageBySenderIdQuery, List<GetMessageBySenderIdQueryResult>>
    {
        private readonly IMessageRepository _messageRepository;

        public GetMessageBySenderIdQueryHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task<List<GetMessageBySenderIdQueryResult>> Handle(GetMessageBySenderIdQuery request, CancellationToken cancellationToken)
        {
            return _messageRepository.GetMessageBySenderId(request.SenderId, request.ReceiverId).Select(a => new GetMessageBySenderIdQueryResult
            {
                SenderID=a.SenderID,    
                ReceiverID=a.ReceiverID,    
                Content=a.Content,  
                CreatedDate=a.CreatedDate,  
                ReadStatus=a.ReadStatus, 
                MessageID=a.MessageID,  

            }).ToList();
        }
    }
}
