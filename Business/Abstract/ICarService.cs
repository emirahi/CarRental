using Core.Utilities;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult update(Car car);
        IResult delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<CarDetailDto> GetCarsById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}

