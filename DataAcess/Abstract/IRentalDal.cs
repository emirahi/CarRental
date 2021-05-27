using Core.DataAccess;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepositoryBase<Rental>
    {
        List<RentalDetailDto> GetRentalDetails();
        RentalDetailDto GetRentalByBrandModel(string brandModel);
        List<RentalOfCar> GetAllRentalOfCars();
    }
}
