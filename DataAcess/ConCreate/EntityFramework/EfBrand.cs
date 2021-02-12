using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.ConCreate.EntityFramework;
using Entity.ConCreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.ConCreate
{
    public class EfBrand:EfEntityRepositoryBase<Brand,CarProjectContext>,IBrandDal
    {
    }
}
