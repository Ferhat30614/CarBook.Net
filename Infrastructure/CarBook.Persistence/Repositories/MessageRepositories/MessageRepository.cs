using CarBook.Application.Interfaces.MessageInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
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
    }
}
