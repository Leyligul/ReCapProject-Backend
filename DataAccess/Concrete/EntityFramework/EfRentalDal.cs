using Core.DataAccess.EntityFrameWork;
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

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join a in context.Car
                             on r.carId equals a.carId
                             
                             join b in context.Brand
                             on a.brandId equals b.brandId

                             join c in context.Users
                            on r.userId equals c.userId


                             select new RentalDetailDto
                             {
                                 brandName=b.brandName,
                                 firstAndLastName=c.firstName+" "+c.lastName,
                                 rentDate=r.rentDate,
                                 returnDate=r.returnDate,
                                


                             };
                return result.ToList();
            }

        }

    }
}
