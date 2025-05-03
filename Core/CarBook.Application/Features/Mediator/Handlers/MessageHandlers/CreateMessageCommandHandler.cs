using CarBook.Application.Features.Mediator.Commands.MessageCommands;
using CarBook.Application.Interfaces.MessageInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.MessageHandlers
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public CreateMessageCommandHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            _messageRepository.CreateMessage(new Message
            {
                SenderID = request.SenderID,    
                ReceiverID = request.ReceiverID,    
                Content = request.Content,  
                CreatedDate = DateTime.Now,  
                ReadStatus= false,  


            });
        }
    }
}
