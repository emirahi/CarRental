using Business.Abstract;
using Core.Entities;
using DataAccess.Abstract;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ConCreate
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal entity)
        {
            _carDal = entity;
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetALL();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetail();
        }

        public CarDetailDto GetCarsById(int carId)
        {
            return _carDal.GetCarDetailID(carId);
        }

        public void update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
