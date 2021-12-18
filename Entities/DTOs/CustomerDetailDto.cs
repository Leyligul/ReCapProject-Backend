using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CustomerDetailDto : IDto
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }    
        public int rentalId { get; set; }
        
    }
}
