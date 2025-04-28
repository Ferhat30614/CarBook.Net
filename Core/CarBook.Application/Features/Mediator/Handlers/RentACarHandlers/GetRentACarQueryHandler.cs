using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using CarBook.Application.Features.Mediator.Results.RentACarResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.Interfaces.RentACarIntefaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery,List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _rentACarRepository;
        private readonly ICarPricingRepository _carPricingRepository;

        public GetRentACarQueryHandler(IRentACarRepository rentACarRepository, ICarPricingRepository carPricingRepository)
        {
            _rentACarRepository = rentACarRepository;
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values =  await _rentACarRepository.GetByFilterAsync(x=>x.LocationID==request.LocationID && x.Available==true);

            return values.Select(y => new GetRentACarQueryResult
            {
                CarID = y.CarID,  
                Brand=y.Car.Brand.Name,
                Model=y.Car.Model,
                CoverImageUrl=y.Car.CoverImageUrl,  
                Amount=_carPricingRepository.GetDailyPriceByCarId(y.CarID), 

            }).ToList();    
        }
    }
}
