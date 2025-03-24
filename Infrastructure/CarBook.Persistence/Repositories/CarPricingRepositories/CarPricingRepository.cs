using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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

                command.CommandText = "Select * From (Select Brands.Name,Cars.Model,CoverImageUrl,PricingID,Amount From CarPricings inner join " +
                    "Cars on Cars.CarID=CarPricings.CarID\r\ninner join Brands on Brands.BrandID=Cars.BrandID) as SourceTable Pivot(Sum(Amount)" +
                    " for PricingID In ([3],[4],[9])) as PivotTable";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader=command.ExecuteReader())
                {
                    while (reader.Read())//okuma işlemi devam ediyosa
                    {
                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
                        {
                            Model = reader["Model"].ToString(),
                            BrandName = reader["Name"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            Amounts = new List<decimal> {

                                reader[3]!=DBNull.Value ? Convert.ToDecimal(reader[3]) : 0,
                                reader[4]!=DBNull.Value ? Convert.ToDecimal(reader[4]) : 0,
                                reader[5]!=DBNull.Value ? Convert.ToDecimal(reader[5]) : 0,

                                    
                            }
                        };
                        values.Add(carPricingViewModel);        
                    }
                    _context.Database.CloseConnection();
                    return values;
                }
            }
        }
    }
}

