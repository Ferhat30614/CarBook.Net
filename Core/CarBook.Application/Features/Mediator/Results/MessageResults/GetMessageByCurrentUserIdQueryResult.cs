﻿using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.MessageResults
{
    public class GetMessageByCurrentUserIdQueryResult
    {        
        public int CurrentUserID { get; set; }
        public int OtherUserID { get; set; }
        public string OtherUserName { get; set; }
        public DateTime LastMessageDate { get; set; }
        public string LastMessageContent { get; set; }
        public int NumberOfUnReadMessagesCount { get; set; }
       
    }
}
