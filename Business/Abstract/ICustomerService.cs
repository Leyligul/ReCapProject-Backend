using System;
using System.Collections.Generic;
using System.Linq;
using Core.Utilities.Results;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
        IResult AddCustomer(Customer customer);
        IResult UpDateCustomer(Customer customer);
        IResult DeleteCustomer(Customer customer);
    }
}
