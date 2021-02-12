using Core.DataAccess;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepositoryBase<Car>
    {
        List<CarDetailDto> GetCarDetail();
        CarDetailDto GetCarDetailID(int id);
    }
}
