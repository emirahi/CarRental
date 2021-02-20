using Core.Utilities;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult update(User user);
        IResult delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<UserDetailDto> GetUsersByFirstName(string FirstName);
        IDataResult<List<UserDetailDto>> GetUserDetails();
    }
}
