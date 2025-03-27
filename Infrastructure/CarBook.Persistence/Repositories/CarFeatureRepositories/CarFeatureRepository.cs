﻿using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public void ChangeCarFeatureAvailableToFalse(int CarFeatureID)
        {
            var values=_context.CarFeatures.Where(x=>x.CarFeatureID==CarFeatureID).FirstOrDefault();    
            values.Available=false;
            _context.SaveChanges();     
        }

        public void ChangeCarFeatureAvailableToTrue(int CarFeatureID)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureID == CarFeatureID).FirstOrDefault();
            values.Available = true;
            _context.SaveChanges();
        }

        public List<CarFeature> GetCarFeaturesByCarId(int CarID)
        {
            var values=_context.CarFeatures.Include(y=>y.Feature).Where(x=>x.CarID==CarID).ToList();     
            return values;
        }
    }
}
