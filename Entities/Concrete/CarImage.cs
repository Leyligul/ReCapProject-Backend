using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {
        public int id { get; set; }
        public int carId { get; set; }
        public string imagePath { get; set; }
        public DateTime date { get; set; }
    }
}
