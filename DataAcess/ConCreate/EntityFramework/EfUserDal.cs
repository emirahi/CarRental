using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.ConCreate.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarProjectContext>, IUserDal
    {
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
                                 Email = u.Email,
                                 Password = u.Password
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
                                 Email = u.Email,
                                 Password = u.Password
                             };
                return result.SingleOrDefault();
            }
        }

     
    }
}
