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

        public 
    }
}
