using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {

        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> ContactRepository)
        {
            _repository = ContactRepository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var values = await _repository.GetByIdAsync(command.ContactID);

            values.ContactID = command.ContactID;
            values.Name = command.Name;
            values.Message = command.Message;
            values.Subject = command.Subject;
            values.Email = command.Email;
            values.SendDate = command.SendDate;
            await _repository.UpdateAsync(values);



        }
    }
}
