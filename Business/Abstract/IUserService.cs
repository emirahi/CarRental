using Core.Utilities;
using Core.Utilities.Business;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<UserDetailDto> GetUsersByFirstName(string FirstName);
        IDataResult<List<UserDetailDto>> GetUserDetails();
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
        IResult Add(User entity);
        IResult update(User entity);
        IResult delete(User entity);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(User entity);
    }
}
