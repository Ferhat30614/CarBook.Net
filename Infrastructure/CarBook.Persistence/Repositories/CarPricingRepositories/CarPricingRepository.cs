using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithPricing()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).
                Include(z => z.Pricing).Where(c=>c.PricingID==3).ToList();   

            return values;  
        }

        public List<CarPricingViewModel> GetCarPricingWithTimePeriod()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();

            using (var command=_context.Database.GetDbConnection().CreateCommand()){

                command.CommandText = "Select * From (Select CarID,PricingID,Amount From CarPricings) " +
                    "as SourceTable Pivot(Sum(Amount) for PricingID In ([2],[3],[4])) as PivotTable";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader=command.ExecuteReader())
                {
                    while (reader.Read())//okuma işlemi devam ediyosa
                    {
                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel();

                        Enumerable.Range(1, 3).ToList().ForEach(x =>
                        {
                            if (DBNull.Value.Equals(reader[x]))
                            {
                                carPricingViewModel.Amounts.Add(0);     
                            }
                            else
                            {
                                carPricingViewModel.Amounts.Add(reader.GetDecimal(x));
                            }                           
                        });
                        values.Add(carPricingViewModel);




                    }
                    _context.Database.CloseConnection();
                    return values;
                }                
            }           

        }
    }
}
