using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.ConCreate.EntityFramework;
using Entity.ConCreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.ConCreate.EntityFramework
{
    public class EfColorDal:EfEntityRepositoryBase<Color,CarProjectContext>
    {
    }
}
