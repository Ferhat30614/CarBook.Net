using CarBook.Application.Features.Mediator.Commands.MessageCommands;
using CarBook.Application.Interfaces.MessageInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.MessageHandlers
{
    public class UpdateReadStatusBySenderCommandHandler : IRequestHandler<UpdateReadStatusBySenderCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public UpdateReadStatusBySenderCommandHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public Task Handle(UpdateReadStatusBySenderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
