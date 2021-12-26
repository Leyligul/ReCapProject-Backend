using Business.Abstract;
using Business.Constants;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult AddBrand(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckBrandName(brand.brandName));
            if (result != null)
            {
                return result; ;
            }
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        public IResult DeleteBrand(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Brand>> GetBrandById(int id)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(p => p.brandId == id));
        }

        public IResult UpDateBrand(Brand brand)
        {
            _brandDal.UpDate(brand);
            return new SuccessResult();
        }



        private IResult CheckBrandName(string brandName)
        {
            var result = _brandDal.GetAll(p => p.brandName == brandName);
            if (result == null || result.Count == 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.BrandAlreadyExist);
        }
    }
}
