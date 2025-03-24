using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.ViewModels
{
    public class CarPricingViewModel
    {
        public CarPricingViewModel()
        {
            Amounts = new List<decimal>();

        }
        public List<decimal> Amounts { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string  BrandName { get; set; }
    }
}
