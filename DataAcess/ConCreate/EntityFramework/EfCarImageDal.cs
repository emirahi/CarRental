﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.ConCreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.ConCreate.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, CarProjectContext>,ICarImageDal
    {
    }
}
