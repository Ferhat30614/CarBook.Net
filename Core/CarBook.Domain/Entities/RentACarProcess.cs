using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class RentACarProcess
    {
        public int RentACarProcessID{ get; set; }
        public int CarID{ get; set; }
        public Car Car  { get; set; }
        public int PickUpLocation{ get; set; }
        public int DropOffLocation{ get; set; }
        public int PickUpDate{ get; set; }
        public int DropOffDate{ get; set; }
        public int PickUpTime{ get; set; }
        public int DropOffTime { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer{ get; set; }
        public string PickUpDescription{ get; set; }
        public string DropOffDescription{ get; set; }
        public decimal TotalPrice{ get; set; }
    }
}
