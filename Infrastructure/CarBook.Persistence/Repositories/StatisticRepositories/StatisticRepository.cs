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

        public string BlogTitleByMaxBlogComment()
        {
            throw new NotImplementedException();
        }

        public string BrandNameByMaxCar()
        {
            throw new NotImplementedException();
        }

        public int GetAuthorCount()
        {
            var values = _context.Authors.Count();
            return values;
        }

        public double GetAvgRentPriceForDaily()
        {
            //Select Avg(Amount) from CarPricings where CarPricings.PricingID=(select PricingID from Pricings where Name='Günlük');
            var total = _context.CarPricings.Where(z=>z.PricingID==3).Sum(x=>x.Amount);
            var carcaountbypricinıd3 = _context.CarPricings.Where(z => z.PricingID == 3).Count();

            var sonuc = total / carcaountbypricinıd3;
            return sonuc;

        }

        public double GetAvgRentPriceForMonthly()
        {
            throw new NotImplementedException();
        }

        public double GetAvgRentPriceForWeekly()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            throw new NotImplementedException();
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            throw new NotImplementedException();
        }

        public int GetCarCountByTranmissionIsAuto()
        {
            throw new NotImplementedException();
        }

        public int GetLocationCount()
        {

            var values = _context.Locations.Count();
            return values;
        }
    }
}
