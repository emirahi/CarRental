﻿using Core.Utilities;
using Core.Utilities.Business;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService:IBaseService<Car>
    {
        IDataResult<CarDetailDto> GetCarsById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}

