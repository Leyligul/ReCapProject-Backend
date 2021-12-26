using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult AddCarImage(IFormFile formFile, CarImage carImage);
        IResult DeleteCarImage(CarImage carImage);
        IResult UpdateCarImage(IFormFile formFile,CarImage carImage);
        IDataResult<List<CarImage>> GetCarImages(); 
        IDataResult<List<CarImage>> GetCarImageByCarId(int carId);
    }
}
