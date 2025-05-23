﻿using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository
    {
        List<CarPricing> GetCarPricingWithPricing();
        List<CarPricingViewModel> GetCarPricingWithTimePeriod();
        public decimal? GetDailyPriceByCarId(int carId);
    }
}
