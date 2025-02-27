using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using ServiceEntity = CarBook.Domain.Entities.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<ServiceEntity> _repository;

        public UpdateServiceCommandHandler(IRepository<ServiceEntity> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetByIdAsync(request.ServiceID);

            values.ServiceID = request.ServiceID;
            values.Title = request.Title;
                values.Description = request.Description;
                values.ImageUrl = request.ImageUrl;

            await _repository.UpdateAsync(values);
        }
    }
}
