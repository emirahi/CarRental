using Core.Utilities;
using Core.Utilities.Business;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService : IBaseService<Rental>
    { 
        IDataResult<RentalDetailDto> GetRentalByBrandModel(string brandModel);
        IDataResult<List<RentalDetailDto>> GetRentalsDetails();
    }
}
