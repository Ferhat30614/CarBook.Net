using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.MessageCommands
{
    public class CreateMessageCommand:IRequest
    {
        public int SenderID { get; set; }        
        public int ReceiverID { get; set; }        
        public string Content { get; set; }
        public bool ReadStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
