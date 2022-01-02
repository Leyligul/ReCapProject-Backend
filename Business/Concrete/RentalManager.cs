using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {

        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
           _rentalDal= rentalDal;

        }

        public IResult AddRental(Rental rental)
        {
            //var result = CheckReturnDate(rental.carId);


            //if (result.Success)
            //{
            //    _rentalDal.Add(rental);

            //    return new SuccessResult(Messages.Added);

            //}


            //return new ErrorResult(Messages.InvalidRequest);

            _rentalDal.Add(rental);

            return new SuccessResult(Messages.Added);

        }


        //public IResult CheckReturnDate(int carId)
        //{

        //    var dataResult = GetRentalById(carId);
        //    if(dataResult.Data == null || dataResult.Data.returnDate < DateTime.Now)
        //    {
        //        return new SuccessResult();
        //    }

        //    else 
        //    {
        //        return new ErrorResult(Messages.AlreadyRented);
        //    }




        // }

        public IResult CheckRentDate(int carId, DateTime rentDate,DateTime returnDate)
        {
            var result = GetRentalById(carId);
            if (result.Data==null)
            {
                return result;
            }
            else
            {
                if (rentDate > result.Data?.returnDate && returnDate> DateTime.Now)
                {
                    return new SuccessResult(Messages.DateisOk);
                }
                else
                {
                    return new ErrorResult(Messages.DateisNotOk);
                }
            }
        }
          
       


         public IResult DeleteRental(Rental rental)
        {

            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Rental> GetRentalById(int carId)
        {
         
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.carId == carId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult UpDateRental(Rental rental)
        {
            _rentalDal.UpDate(rental);
            return new SuccessResult();
        }
    }
}
