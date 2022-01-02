using Core.Entities.Concrete;
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
    public interface IUserService
    {
        //IDataResult<List<User>> GetAll();
        //IResult AddUser(User user);
        IResult UpDateUser(UserDto userDto);
        //IResult DeleteUser(User user);

        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult AddUser(User user);
        IDataResult<User> GetByMail(string email);
        IResult ChangeUserPassword(PasswordUpDateDto passwordUpDateDto);
    }


    

}
