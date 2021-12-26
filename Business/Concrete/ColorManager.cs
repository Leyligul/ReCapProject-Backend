using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult AddColor(Color color)
        {
            IResult result = BusinessRules.Run(CheckColorName(color.colorName));
            if (result != null)
            {
                return result; ;
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);

        }

        public IResult DeleteColor(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Color>> GetColorById(int colorId)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(p=>p.colorId==colorId), Messages.Listed);
        }

        public IResult UpDateColor(Color color)
        {
            _colorDal.UpDate(color);
            return new SuccessResult();
        }


        private IResult CheckColorName(string colorName)
        {
            var result = _colorDal.GetAll(p => p.colorName == colorName);
            if (result == null || result.Count==0)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ColorAlreadyExist);
        }
    }
}
