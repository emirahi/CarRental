using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entity.ConCreate;
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
            throw new NotImplementedException();
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
