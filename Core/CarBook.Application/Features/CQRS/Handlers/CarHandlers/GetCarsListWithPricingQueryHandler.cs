using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarsListWithPricingQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarsListWithPricingQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public List<GetCarsListWithPricingQueryResult> Handle()
        {
            var values = _carRepository.GetCarsListWithPricing();

            return values.Select(x => new GetCarsListWithPricingQueryResult
            {
                Model=x.Car.Model,
                BrandName=x.Car.Brand.Name, 
                PricingAmount=x.Amount, 
                CoverImageUrl=x.Car.CoverImageUrl,

            }).ToList();


        }

    }
}
