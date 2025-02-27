using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using ServiceEntity = CarBook.Domain.Entities.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly IRepository<ServiceEntity> _repository;

        public CreateServiceCommandHandler(IRepository<ServiceEntity> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new ServiceEntity
            {
                Title = request.Title,
                Description = request.Description,
                ImageUrl = request.ImageUrl,

            });
        }
    }
}
