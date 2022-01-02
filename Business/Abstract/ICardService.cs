using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICardService
    {
        IDataResult<List<Card>> GetAll();
         IDataResult<Card> GetCardByUserId(int userId);
        IResult AddCard(Card card);
        IResult DeleteCard(Card card);

        IResult UpDateCard(Card card);
    }
}
