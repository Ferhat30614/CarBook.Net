using CarBook.Application.Features.Mediator.Results.MessageResults;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.MessageInterfaces
{
    public interface IMessageRepository
    {
        void CreateMessage(Message message);
        List<Message> GetMessageBySenderId(int senderId, int receiverId);
        List<GetMessageByCurrentUserIdQueryResult> GetMessageByCurrentUser(int CurrentUserId);
        public string GetUserNameByOtherUserId(int OtherUserId);
        

    }
}
