using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarWithBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetLast5CarWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public List<GetLast5CarWithBrandQueryResult> Handle()
        {
            var values=_carRepository.GetLast5CarsWithBrands();

            return values.Select(x => new GetLast5CarWithBrandQueryResult
            {

                CarID = x.CarID,
                BrandID = x.BrandID,
                BrandName = x.Brand.Name,
                Model = x.Model,
                CoverImageUrl = x.CoverImageUrl,
                Km = x.Km,
                Transmission = x.Transmission,
                Seat = x.Seat,
                Luggage = x.Luggage,
                Fuel = x.Fuel,
                BigImageUrl = x.BigImageUrl

            }).ToList();


        }
    }
}
