using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Interfaces;
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
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {


        private readonly ICarFeatureRepository _carFeatureRepository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async  Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _carFeatureRepository.GetCarFeaturesByCarId(request.Id);
            return values.Select(x => new GetCarFeatureByCarIdQueryResult
            {
               FeatureID = x.FeatureID, 
               CarFeatureID = x.CarFeatureID,       
               Available=x.Available,   
            }).ToList();
        }
    }
}
