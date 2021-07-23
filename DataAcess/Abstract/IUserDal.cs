using Core.DataAccess;
using Core.Entities.Dtos;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal: IEntityRepositoryBase<User>
    {
        List<UserDetailDto> GetUserDetails();
        UserDetailDto GetUserDetailFirstName(string FirstName);
        List<OperationClaim> GetClaims(User user);

        UserDto GetByUserMail(string email);
    }
}
