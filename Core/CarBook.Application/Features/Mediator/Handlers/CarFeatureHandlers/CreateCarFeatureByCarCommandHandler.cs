using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class CreateCarFeatureByCarCommandHandler : IRequestHandler<CreateCarFeatureByCarCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public CreateCarFeatureByCarCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(CreateCarFeatureByCarCommand request, CancellationToken cancellationToken)
        {
            var value = await _carFeatureRepository.CheckCarFeatureByFilter(a=>a.CarID==request.CarID && a.FeatureID==request.FeatureID);

            if (value==false)
            {
                _carFeatureRepository.CreateCarFeatureByCar(new CarFeature
                {
                    Available = false,
                    CarID = request.CarID,
                    FeatureID = request.FeatureID,
                });

            }


            
        }
    }
}
