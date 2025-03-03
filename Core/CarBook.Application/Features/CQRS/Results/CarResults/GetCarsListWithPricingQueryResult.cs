using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.CarResults
{
    public class GetCarsListWithPricingQueryResult
    {
        public string Model { get; set; }
        public string BrandName { get; set; }
        public string CoverImageUrl { get; set; }
        public  decimal PricingAmount { get; set; }
        public  decimal PricingName { get; set; }
    }
}
