﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarPricingDtos
{
    public class ResultCarPricingsListWithCarsDto
    {

            public int CarId { get; set; }
            public int CarPricingID { get; set; }
            public decimal Amount { get; set; }
            public string Model { get; set; }
            public string BrandName { get; set; }
            public string CoverImageUrl { get; set; }
            public string PricingName { get; set; }
        

    }
}
