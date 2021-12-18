using Core.DataAccess.EntityFrameWork;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
       

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from a in context.Car
                             join b in context.Brand
                             on a.brandId equals b.brandId
                             join c in context.Color
                             on a.colorId equals c.colorId
                            

                             select new CarDetailDto
                             {
                                 carName = a.carName,
                                 brandName = b.brandName,
                                 colorName = c.colorName,
                                 dailyPrice = a.dailyPrice,
                                 description = a.description,
                                 
                             };
                         return result.ToList();
            }

        }
    }
}
