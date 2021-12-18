using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Rental :IEntity
    {
        public int id { get; set; }
        public int carId { get; set; }
        public int userId { get; set; }
        public DateTime rentDate { get; set; }
        public DateTime ? returnDate { get; set; }
    }
}
