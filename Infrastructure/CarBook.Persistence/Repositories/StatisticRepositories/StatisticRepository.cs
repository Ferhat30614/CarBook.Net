using CarBook.Application.Interfaces.StatisticInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
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
            //select top (1 ) Brands.Name,COUNT(*) as 'ToplamArac' from Cars inner join Brands on Brands.BrandID = Cars.BrandID 
            //group by Brands.Name order by toplamarac desc

            var values = _context.Cars.GroupBy(a => a.BrandID).Select(b => new
            {
                BrandId = b.Key,
                ferhat = b.Count()
            }).OrderByDescending(c=>c.ferhat).FirstOrDefault();

            string brandName = _context.Brands.Where(d => d.BrandID == values.BrandId).Select(e=>e.Name).FirstOrDefault();  

            return brandName;
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
            int pricingID = _context.Pricings.Where(c => c.Name == "Günlük").Select(d => d.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(a => a.PricingID == pricingID).Max(b => b.Amount);
            int carId = _context.CarPricings.Where(e => e.Amount == amount).Select(f => f.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Include(g => g.Brand).Where(h => h.CarID == carId).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            int pricingID = _context.Pricings.Where(c => c.Name == "Günlük").Select(d => d.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(a => a.PricingID == pricingID).Min(b => b.Amount);
            int carId = _context.CarPricings.Where(e => e.Amount == amount).Select(f => f.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Include(g => g.Brand).Where(h => h.CarID == carId).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
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
