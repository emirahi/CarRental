using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ConCreate
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetALL());
        }

        public IDataResult<List<RentalOfCar>> GetAllRentalOfCars()
        {
            return new SuccessDataResult<List<RentalOfCar>>(_rentalDal.GetAllRentalOfCars());
        }

        public IDataResult<Rental> GetById(Rental entity)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalsId == entity.RentalsId));
        }

        public IDataResult<RentalDetailDto> GetRentalByBrandModel(string brandModel)
        {
            return new SuccessDataResult<RentalDetailDto>(_rentalDal.GetRentalByBrandModel(brandModel));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
