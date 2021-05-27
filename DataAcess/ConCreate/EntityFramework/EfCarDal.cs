using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.ConCreate.EntityFramework;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;


namespace DataAccess.ConCreate.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarProjectContext>, ICarDal
    {
        public CarDetailDto GetCarDetailID(int id)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from c in context.Cars
                             where c.Id == id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join k in context.Colors
                             on c.ColorId equals k.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 ColorId = k.ColorId,
                                 ColorName = k.ColorName,
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Descriptions = c.Descriptions
                             };
                return result.SingleOrDefault();
            }
        }

        public List<CarDetailDto> GetCarDetail()
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join k  in context.Colors                             
                             on c.ColorId equals k.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 ColorId = k.ColorId,
                                 ColorName = k.ColorName,
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Descriptions = c.Descriptions
                             };
                return result.ToList();
            }
        }

        public Car GetById(int id)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                return context.Cars.SingleOrDefault(c => c.Id == id);
            }
        }

        public List<CarByBrandDto> GetByBrandName(string brandName)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var query = from b in context.Brands
                            join c in context.Cars
                            on b.BrandName equals brandName
                            join color in context.Colors
                            on c.ColorId equals color.ColorId
                            where c.BrandId == b.BrandId
                            select new CarByBrandDto
                            {
                                Id = c.Id,
                                BrandName = b.BrandName,
                                ColorName = color.ColorName,
                                DailyPrice = c.DailyPrice,
                                ModelYear = c.ModelYear,
                                Descriptions = c.Descriptions
                            };
                var q = query.ToList();

                return query.ToList();
            }
        }

        public List<CarByColorDto> GetByColorName(string colorName)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var query = from color in context.Colors
                            join c in context.Cars
                            on color.ColorName equals colorName
                            join b in context.Brands
                            on c.BrandId equals b.BrandId
                            select new CarByColorDto
                            {
                                Id = c.Id,
                                BrandName = b.BrandName,
                                ColorName = color.ColorName,
                                DailyPrice = c.DailyPrice,
                                ModelYear = c.ModelYear,
                                Descriptions = c.Descriptions
                            };
                return query.ToList();
            }
        }

        public List<CarDto> GetAllDto()
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from c in context.Cars
                             join color in context.Colors
                             on c.ColorId equals color.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Descriptions = c.Descriptions
                             };
                return result.ToList();
            }
        }
    }
}

