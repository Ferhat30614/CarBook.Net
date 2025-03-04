﻿using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repository;
        public RemoveAuthorCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveTagCloudCommand request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);  
        }
    }
}
