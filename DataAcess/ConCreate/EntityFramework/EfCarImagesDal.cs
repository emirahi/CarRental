using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.ConCreate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.ConCreate.EntityFramework
{
    public class EfCarImagesDal : EfEntityRepositoryBase<CarImages, CarProjectContext>, ICarImagesDal
    {

    }
}
