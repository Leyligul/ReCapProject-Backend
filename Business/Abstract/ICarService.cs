using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{ 
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();

        IDataResult<Car> GetById(int carId);
        IResult AddCar(Car car);
        IResult UpDateCar(Car car);
        IResult DeleteCar(Car car);
        IResult AddTransactionalTest(Car car); //uygulamalrda tutarlılığı korumak için yapılan bir yöntem



    }
}
