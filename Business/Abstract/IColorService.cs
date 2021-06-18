using Core.Utilities;
using Core.Utilities.Business;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color entity);
        IResult update(Color entity);
        IResult delete(Color entity);
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(Color entity);

        IDataResult<List<CarByColorDto>> GetByColorId(int colorId);
    }
}
