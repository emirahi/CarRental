using Core.Utilities;
using Core.Utilities.Business;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<CarDetailDto> GetCarsById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult Add(Car entity);
        IResult update(Car entity);
        IResult delete(Car entity);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(Car entity);
        IDataResult<List<CarDto>> GetAllDto();
        IDataResult<List<CarSearchDto>> GetBySearch(int brandId, int colorId);

    }
}

