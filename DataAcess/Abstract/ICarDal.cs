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
        List<CarByBrandDto> GetByBrandName(string brandName);
        List<CarByColorDto> GetByColorName(string colorName);
        List<CarDto> GetAllDto();
        CarDetailDto GetCarDetailID(int id);
        Car GetById(int id);

    }
}
