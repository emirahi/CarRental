using Core.DataAccess;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IColorDal:IEntityRepositoryBase<Color>
    {
        List<CarByColorDto> GetByColorId(int colorId);
    }
}
