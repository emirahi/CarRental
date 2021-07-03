using Core.Utilities;
using Core.Utilities.Business;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    { 
        IDataResult<RentalDetailDto> GetRentalByBrandModel(string brandModel);
        IDataResult<List<RentalDetailDto>> GetRentalsDetails();
        IDataResult<List<RentalOfCar>> GetAllRentalOfCars();
        IResult Add(Rental entity);
        IResult update(Rental entity);
        IResult delete(Rental entity);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(Rental entity);
        IDataResult<RentalOfCar> GetByCarId(int id);
    }
}
