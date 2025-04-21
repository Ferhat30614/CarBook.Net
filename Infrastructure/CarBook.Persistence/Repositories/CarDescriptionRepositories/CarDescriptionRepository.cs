using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        public readonly CarBookContext CarBookContext;

        public CarDescriptionRepository(CarBookContext carBookContext)
        {
            CarBookContext = carBookContext;
        }

        public async Task<CarDescription> GetCarDescription(int carId)
        {
            var values = await CarBookContext.CarDescriptions.Where(x => x.CarID == carId).FirstOrDefaultAsync();
            return values;
        }
    }
}
