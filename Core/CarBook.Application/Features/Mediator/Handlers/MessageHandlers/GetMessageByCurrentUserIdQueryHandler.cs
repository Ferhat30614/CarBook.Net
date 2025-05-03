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
                CurrentUserID= request.CurrentUserID,   
                OtherUserID= a.OtherUserID,
                OtherUserName= _messageRepository.GetUserNameByOtherUserId(a.OtherUserID),  
                LastMessageDate= a.LastMessageDate, 
                LastMessageContent= a.LastMessageContent,       


            }).ToList();    
        }
    }
}
