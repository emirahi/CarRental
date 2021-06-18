using Business.Abstract;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ConCreate
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _BrandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _BrandDal = brandDal;
        }
        [ValidationAspect(typeof(Brand))]
        public IResult Add(Brand brand)
        {
            _BrandDal.Add(brand);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(Brand))]
        public IResult delete(Brand brand)
        {
            _BrandDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_BrandDal.GetALL());
        }

        public IDataResult<List<CarByBrandDto>> GetByBrandId(int brandId)
        {
            var result = _BrandDal.GetByBrandId(brandId);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarByBrandDto>>(result);
            }
            return new ErrorDataResult<List<CarByBrandDto>>("Listelenicek Veri Mevcut değil", result);
        }

        public IDataResult<Brand> GetById(Brand entity)
        {
            return new SuccessDataResult<Brand>(_BrandDal.Get(b => b.BrandId == entity.BrandId));
        }

        [ValidationAspect(typeof(Brand))]
        public IResult update(Brand brand)
        {
            _BrandDal.Update(brand);
            return new SuccessResult();
        }
    }
}
