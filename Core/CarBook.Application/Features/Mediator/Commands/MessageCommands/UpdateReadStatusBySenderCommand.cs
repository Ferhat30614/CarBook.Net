using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.MessageCommands
{
    public class UpdateReadStatusBySenderCommand:IRequest
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}
