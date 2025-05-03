using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.MessageResults
{
    public class GetMessageBySenderIdQueryResult
    {
        public int MessageID { get; set; }
        public int SenderID { get; set; }      
        public int ReceiverID { get; set; }       
        public string Content { get; set; }
        public bool ReadStatus { get; set; }
        public string OtherUserName { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
