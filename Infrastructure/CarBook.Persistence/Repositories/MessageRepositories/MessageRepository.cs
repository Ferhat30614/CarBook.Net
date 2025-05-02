using CarBook.Application.Interfaces.MessageInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly CarBookContext _carBookContext;

        public MessageRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public void CreateMessage(Message message)
        {
            _carBookContext.Messages.Add(message);  
            _carBookContext.SaveChanges();  
        }       

        public List<Message> GetMessageBySenderId(int senderId, int receiverId)
        {
            var value=_carBookContext.Messages
                .Where(a=>(a.SenderID==senderId && a.ReceiverID==receiverId) || (a.SenderID == receiverId && a.ReceiverID == senderId)  )
                .ToList();
            return value;

        }

        public List<Message> GetMessageByCurrentUser(int CurrentUserId)
        {
            return _carBookContext.Messages
                .Include(b => b.Sender)
                .Include(c => c.Receiver)
                .Where(a => a.SenderID == CurrentUserId || a.ReceiverID == CurrentUserId)
                .ToList();
        }
    }
}
