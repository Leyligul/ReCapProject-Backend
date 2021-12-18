using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.IO;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Core.Utilities.Helpers;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelperService _fileHelperService;

        public CarImageManager(ICarImageDal carImageDal, IFileHelperService fileHelperService)
        {
            _carImageDal = carImageDal;
            _fileHelperService = fileHelperService;

        }



        public IResult AddCarImage(IFormFile formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageNumber(carImage.carId));
               // CheckSameCarImage(formFile,carImage.carId));
            if (result != null)
            {
                return result;
            }

            IDataResult<string> fileUploadResult = _fileHelperService.Upload(formFile, PathConstants.ImagePath);
            carImage.imagePath = fileUploadResult.Data;

            carImage.date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.Added);
        }

        public IResult DeleteCarImage(CarImage carImage)
        {
            _fileHelperService.Delete(carImage.imagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarImage>> GetCarImages()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult UpdateCarImage(IFormFile formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageNumber(carImage.carId));
            if (result != null)
            {
                return result;
            }
            _fileHelperService.Update(formFile, carImage.imagePath, PathConstants.ImagePath);
            carImage.date = DateTime.Now;
            _carImageDal.UpDate(carImage);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckCarImageNumber(int carId)
        {
            var result = _carImageDal.GetAll(p => p.carId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageNumberError);
            }

            return new SuccessResult();



        }

        //private IResult CheckSameCarImage(IFormFile formFile, int carId)
        //{
        //    var allImages = _carImageDal.GetAll(p => p.carId == carId);
        //    using (MemoryStream memoryStream = new MemoryStream())
        //    {
        //        formFile.CopyTo(memoryStream);
        //        byte[] fileBytes = memoryStream.ToArray();



        //        foreach (var image in allImages)
        //        {
        //            byte[] imageByte = File.ReadAllBytes(image.imagePath);
        //            if (fileBytes.SequenceEqual( imageByte))
        //            {
        //                return new ErrorResult("Zaten kayıtlı.");
        //            }
        //        }


        //    }
        //    return new SuccessResult();

        //}



    }
}
