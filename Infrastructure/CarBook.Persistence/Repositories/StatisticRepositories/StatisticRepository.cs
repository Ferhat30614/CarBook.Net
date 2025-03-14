using CarBook.Application.Interfaces.StatisticInterfaces;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly CarBookContext _context;

        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            throw new NotImplementedException();
        }

        public string GetBrandNameByMaxCar()
        {
            throw new NotImplementedException();
        }

        public int GetAuthorCount()
        {
            var values = _context.Authors.Count();
            return values;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            //Select Avg(Amount) from CarPricings where CarPricings.PricingID=(select PricingID from Pricings where Name='Günlük');

            int id = _context.Pricings.Where(z => z.Name == "Günlük").Select(f => f.PricingID).FirstOrDefault();
            var values = _context.CarPricings.Where(x => x.PricingID == id).Average(y => y.Amount);

            return values;

        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(z => z.Name == "Aylık").Select(f => f.PricingID).FirstOrDefault();
            var values = _context.CarPricings.Where(x => x.PricingID == id).Average(y => y.Amount);

            return values;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(z => z.Name == "Haftalık").Select(f => f.PricingID).FirstOrDefault();
            var values = _context.CarPricings.Where(x => x.PricingID == id).Average(y => y.Amount);

            return values;
        }

        public int GetBlogCount()
        {

            var values = _context.Blogs.Count();
            return values;
        }

        public int GetBrandCount()
        {

            var values = _context.Brands.Count();
            return values;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            throw new NotImplementedException();
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            throw new NotImplementedException();
        }

        public int GetCarCount()
        {

            var values = _context.Cars.Count();
            return values;
        }

        public int GetCarCountByFuelElectric()
        {
            var values = _context.Cars.Where(x => x.Fuel == "Elektrik" ).Count();
            return values;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var values = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return values;  
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            var values = _context.Cars.Where(x => x.Km <=1000).Count();
            return values;
        }

        public int GetCarCountByTranmissionIsAuto()
        {
            var values = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return values;  
        }

        public int GetLocationCount()
        {
            var values = _context.Locations.Count();
            return values;
        }
    }
}
