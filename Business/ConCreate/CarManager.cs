using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using Core.Utilities;
using Core.Utilities.Business;
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

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.GetAll")]
        [TransactionScopeAspect]
        public IResult Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessResult();
        }

        public IResult delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {            
            return new SuccessDataResult<List<Car>>(_carDal.GetALL());
        }

        [CacheAspect()]
        public IDataResult<List<CarDto>> GetAllDto()
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetAllDto());
        }

        [ValidationAspect(typeof(CarByBrandValidator))]
        public IDataResult<List<CarByBrandDto>> GetByBrandName(string brandName)
        {
            return new SuccessDataResult<List<CarByBrandDto>>(_carDal.GetByBrandName(brandName));
        }

        public IDataResult<List<CarByColorDto>> GetByColorName(string colorName)
        {
            return new SuccessDataResult<List<CarByColorDto>>(_carDal.GetByColorName(colorName));
        }

        public IDataResult<Car> GetById(Car entity)
        {
            return new SuccessDataResult<Car>(_carDal.GetById(entity.Id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail());
        }

        public IDataResult<CarDetailDto> GetCarsById(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailID(carId));
        }

        public IResult update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        private bool CarDtoListLenght(List<CarDto> carDtoList)
        {
            return carDtoList.Count > 0 ? true : false;
        }

    }
}
