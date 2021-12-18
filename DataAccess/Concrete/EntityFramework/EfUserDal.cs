using Core.DataAccess.EntityFrameWork;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext> , IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.id equals userOperationClaim.operationClaimId
                             where userOperationClaim.userId == user.userId
                             select new OperationClaim { id = operationClaim.id, name = operationClaim.name };
                return result.ToList();

            }
        }

    }
}
