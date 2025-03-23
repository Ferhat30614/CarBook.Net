using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler:IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingWithCarQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async  Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {   

            var values = _carPricingRepository.GetCarPricingWithPricing();

            return values.Select(x => new GetCarPricingWithCarQueryResult
            {
                CarPricingID = x.CarPricingID,  
                Amount = x.Amount,  
                Model=x.Car.Model,               
                BrandName=x.Car.Brand.Name,
                CoverImageUrl=x.Car.CoverImageUrl,  
                PricingName=x.Pricing.Name,
                CarId=x.CarID,
            }).ToList();
        }
    }
}
