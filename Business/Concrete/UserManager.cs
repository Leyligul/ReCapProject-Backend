using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;

        }



        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult AddUser(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.mail == email));
        }

     
       // [ValidationAspect(typeof(UserValidator))]
        public IResult UpDateUser(UserDto userDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userDto.password, out passwordHash, out passwordSalt);
            var user = new User
            { 
                userId = userDto.userId,
                mail = userDto.mail,
                firstName = userDto.firstName,
                lastName = userDto.lastName,
                passwordHash = passwordHash,
                passwordSalt = passwordSalt,
                status = true
            };

            _userDal.UpDate(user);
            return new SuccessResult();
        }

        public IResult ChangeUserPassword(PasswordUpDateDto passwordUpDateDto)
        {
            byte[] passwordHash, passwordSalt;
            var userToCheck = GetByMail(passwordUpDateDto.Email);
            //if (userToCheck.Data == null)
            //{
            //    return new ErrorResult(Messages.UserNotFound);
            //}
            if (!HashingHelper.VerifyPasswordHash(passwordUpDateDto.OldPassword, userToCheck.Data.passwordHash, userToCheck.Data.passwordHash))
            {
                return new ErrorResult(Messages.PasswordError);
            }
            HashingHelper.CreatePasswordHash(passwordUpDateDto.NewPassword, out passwordHash, out passwordSalt);
            userToCheck.Data.passwordHash = passwordHash;
            userToCheck.Data.passwordSalt = passwordSalt;
            _userDal.UpDate(userToCheck.Data);
            return new SuccessResult(Messages.PasswordChanged);
        }
    }
}
