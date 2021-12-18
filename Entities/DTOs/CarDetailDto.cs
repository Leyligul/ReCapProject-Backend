
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public string carName { get; set; }
        public string brandName { get; set; }
        public string colorName { get; set; }
        public decimal dailyPrice { get; set; }
      //  public DateTime returnDate { get; set; }    
      public string description { get; set; }


    }
}
