using CarBook.Application.Features.Mediator.Queries.MessageQueries;
using CarBook.Application.Features.Mediator.Results.MessageResults;
using CarBook.Application.Interfaces.MessageInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                .OrderBy(a=>a.CreatedDate)
                .ToList();
            return value;

        }

        public List<GetMessageByCurrentUserIdQueryResult > GetMessageByCurrentUser(int CurrentUserId)
        {
            return _carBookContext.Messages
                .Include(f=>f.Sender)
                .Include(g=>g.Receiver)
                .Where(a => a.SenderID == CurrentUserId || a.ReceiverID == CurrentUserId)
                .GroupBy(b => new
                {
                    OtherUserId = (b.SenderID == CurrentUserId) ? b.ReceiverID : b.SenderID,
                }).Select(b => new GetMessageByCurrentUserIdQueryResult
                {
                    OtherUserID = b.Key.OtherUserId,
                    LastMessageDate = b.Max(c => c.CreatedDate),
                    LastMessageContent = b
                    .OrderByDescending(d => d.CreatedDate)
                    .Select(e => e.Content)
                    .FirstOrDefault()
                }).ToList();
        }


        public string GetUserNameByOtherUserId(int OtherUserId) {


            return _carBookContext.AppUsers
                .Where(a => a.AppUserId == OtherUserId)
                .Select(b => b.UserName)
                .FirstOrDefault();
        
        }

        public void UpdateReadStatusBySender(int senderId, int receiverId)
        {
            var values=_carBookContext.Messages
                .Where(a=>a.SenderID==senderId && a.ReceiverID==receiverId && a.ReadStatus==false )
                .ToList();

            foreach (var value in values) { 
            
                value.ReadStatus = true;
                _carBookContext.Messages.Update(value);
            }

            _carBookContext.SaveChanges(); 
        }

        public int GetNumberOfUnReadMessagesBySenderId(int senderId, int receiverId)
        {
            return _carBookContext.Messages
                .Where(a=>a.SenderID==senderId && a.ReceiverID==receiverId && a.ReadStatus==false)
                .Count();   
        }
    }
}
