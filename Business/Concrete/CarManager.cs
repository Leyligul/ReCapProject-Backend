using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Performance;
using Core.Aspects.Transaction;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;

using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;


        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }

        [CacheAspect] //key,value
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);

        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.brandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.colorId == id));
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]

        public IResult AddCar(Car car)
        {
            //1)
            //    if (car.carName.Length >=2 && car.dailyPrice > 0)
            //    {
            //        _carDal.Add(car);
            //        return new SuccessResult(Messages.Added);
            //    }

            //        //Console.WriteLine("Not a valid information!");
            //        return new ErrorResult(Messages.InformationInvalid);



            //2)
            //var context = new ValidationContext<Car>(car);
            //CarValidator carValiator = new CarValidator();
            //var result=carValiator.Validate(context);
            //if(!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);

            //}

            //_carDal.Add(car);
            //return new SuccessResult(Messages.Added);



            //3)
            //ValidationTool.Validate(new CarValidator(), car);
            //_carDal.Add(car);
            //return new SuccessResult(Messages.Added);


            //4)**
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [CacheAspect]
        [PerformanceAspect(1)] //Methodun çalışması 5 sn den uzun sürerse sistemde bir yavaşlık var ! diye kontrol etmemize yarıyor.
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.carId == carId)," araba geldi");
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult UpDateCar(Car car)
        {
            _carDal.UpDate(car);
            return new SuccessResult(Messages.Updated);
        }

        public IResult DeleteCar(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {   
            _carDal.Add(car);
            _carDal.UpDate(car);
           
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<CarDetailDto> GetCarDetailById(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailsById(carId));


        }

        public IDataResult<List<Car>> GetCarsByColorIdAndBrandId(int colorId, int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.colorId == colorId && p.brandId == brandId));
        }
    }
}
