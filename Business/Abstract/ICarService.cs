using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void update(Car car);
        void delete(Car car);
        List<Car> GetAll();
        CarDetailDto GetCarsById(int carId);
        List<CarDetailDto> GetCarDetails();
    }
}

