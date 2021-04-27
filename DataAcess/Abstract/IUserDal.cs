using Core.DataAccess;
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
    }
}
