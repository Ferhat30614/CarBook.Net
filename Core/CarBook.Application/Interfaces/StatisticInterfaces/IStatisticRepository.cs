using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.StatisticInterfaces
{
    public interface IStatisticRepository
    {
        int GetCarCount();
        int GetLocationCount();
        int GetAuthorCount();
        int GetBlogCount();
        int GetBrandCount();
        double GetAvgRentPriceForDaily();
        double GetAvgRentPriceForWeekly();
        double GetAvgRentPriceForMonthly();
        int GetCarCountByTranmissionIsAuto();
        string BrandNameByMaxCar();
        string BlogTitleByMaxBlogComment();
        int GetCarCountByKmSmallerThen1000();
        int GetCarCountByFuelGasolineOrDiesel();
        int GetCarCountByFuelElectric();
        string GetCarBrandAndModelByRentPriceDailyMax();
        string GetCarBrandAndModelByRentPriceDailyMin();
    }
}
