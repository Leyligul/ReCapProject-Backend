using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {

        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from a in context.Customers
                             join b in context.Users
                             on a.userId equals b.userId
                             join r in context.Rentals
                             on a.userId equals r.userId



                             select new CustomerDetailDto
                             {
                                 userId = b.userId,
                                 firstName = b.firstName,
                                 lastName = b.lastName,
                                 rentalId = r.id,
                             };
                return result.ToList();
            }

        }
    }
}
