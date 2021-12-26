using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Card : IEntity
    {
        public int cardId { get; set; }
        public int userId { get; set; }
        public string nameOnCard { get; set; }
        public string cardNumber { get; set; }
        public string cvv { get; set; }
        public DateTime validDate { get; set; }
    }
}
