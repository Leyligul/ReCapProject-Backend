using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        
        public string brandName { get; set; }
      
        public string firstAndLastName { get; set; }
      
        public DateTime rentDate { get; set; }
        public DateTime? returnDate { get; set; }
        
    }
}
