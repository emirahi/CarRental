using Core.Utilities;
using Core.Utilities.Business;
using Entity.ConCreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(Brand entity);
        IResult update(Brand entity);
        IResult delete(Brand entity);
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(Brand entity);

    }
}
