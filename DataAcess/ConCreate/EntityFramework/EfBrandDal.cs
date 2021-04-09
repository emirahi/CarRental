using Core.DataAccess.EntityFramework;
using Core.Utilities;
using DataAccess.Abstract;
using DataAccess.ConCreate.EntityFramework;
using Entity.ConCreate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.ConCreate.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarProjectContext>, IBrandDal
    {

    }
}
