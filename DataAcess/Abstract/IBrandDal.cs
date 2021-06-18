using Core.DataAccess;
using Core.Utilities;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBrandDal:IEntityRepositoryBase<Brand>
    {
        List<CarByBrandDto> GetByBrandId(int brandInt);
    }
}
