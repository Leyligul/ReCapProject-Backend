using Core.Utilities.Results;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IResult AddRental(Rental rental);
        IResult UpDateRental(Rental rental);
        IResult DeleteRental(Rental rental);
        IResult CheckRentDate(int carId, DateTime rentDate, DateTime returnDate);

       // IResult CheckReturnDate(int carId);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();

        IDataResult<Rental> GetRentalById(int carId);

    }
}
