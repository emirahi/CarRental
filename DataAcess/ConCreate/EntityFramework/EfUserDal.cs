using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities.Dtos;

namespace DataAccess.ConCreate.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarProjectContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CarProjectContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UsersId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
        public List<UserDetailDto> GetUserDetails()
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.UsersId equals c.UserId
                             select new UserDetailDto
                             {
                                 UsersId = u.UsersId,
                                 CustomerId = c.CustomerId,
                                 CompanyName = c.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email
                             };
                return result.ToList();
            }
        }

        public UserDetailDto GetUserDetailFirstName(string FirstName)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from u in context.Users
                             where u.FirstName == FirstName
                             join c in context.Customers
                             on u.UsersId equals c.CustomerId
                             select new UserDetailDto
                             {
                                 UsersId = u.UsersId,
                                 CustomerId = c.CustomerId,
                                 CompanyName = c.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email
                             };
                return result.SingleOrDefault();
            }
        }

        public UserDto GetByUserMail(string email)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from u in context.Users
                             where u.Email == email
                             select new UserDto
                             {
                                 UsersId = u.UsersId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 Status = u.Status
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
