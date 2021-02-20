using Core.Utilities;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult update(Rental rental);
        IResult delete(Rental rental);
        IDataResult<List<Rental >> GetAll();
        IDataResult<RentalDetailDto> GetRentalByBrandModel(string brandModel);
        IDataResult<List<RentalDetailDto>> GetRentalsDetails();
    }
}
