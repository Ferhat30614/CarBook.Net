using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.RentACarDtos
{
    public class FilterRentACarDto
    {
        public object LocationID { get; set; }
        public bool Available { get; set; }
    }
}