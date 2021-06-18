using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ConCreate
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IResult Add(Color entity)
        {
            _colorDal.Add(entity);
            return new SuccessResult();
        }

        public IResult delete(Color entity)
        {
            _colorDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetALL());
        }

        public IDataResult<List<CarByColorDto>> GetByColorId(int colorId)
        {
            var result = _colorDal.GetByColorId(colorId);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarByColorDto>>(result);
            }
            return new ErrorDataResult<List<CarByColorDto>>(result);
        }

        public IDataResult<Color> GetById(Color entity)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == entity.ColorId));
        }

        public IResult update(Color entity)
        {
            _colorDal.Update(entity);
            return new SuccessResult();
        }
    }
}
