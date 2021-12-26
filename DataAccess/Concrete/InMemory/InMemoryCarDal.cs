using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                //Brand - > 1) SKODA, 2=)TOYOTA, 3)VOLKSWAGEN

                new Car{carId=1,brandId=1,colorId=1,modelYear="2018",dailyPrice=187,description="MODEL: SUPERB"},
                new Car{carId=2,brandId=2,colorId=2,modelYear="2017",dailyPrice=139,description="MODEL: COROLLA 1.4D -4D"},
                new Car{carId=3,brandId=3,colorId=3,modelYear="2004",dailyPrice=43,description="MODEL : GOLF 1.6 FSİ"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.carId == car.carId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.carId == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public CarDetailDto GetCarDetailsById(int carId)
        {
            throw new NotImplementedException();
        }

        public void UpDate(Car car)
        {
            Car carToUpDate = _cars.SingleOrDefault(c => c.carId == car.carId);
            carToUpDate.dailyPrice = car.dailyPrice;
           
        }
    }
}
