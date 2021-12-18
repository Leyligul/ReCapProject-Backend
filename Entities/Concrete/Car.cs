
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
       
        public int carId { get; set; }
        public string carName { get; set; }
        public int brandId { get; set; }
        public int colorId { get; set; }
        public string modelYear { get; set; }
        public decimal dailyPrice { get; set; }
        public string description { get; set; }

    }




}
