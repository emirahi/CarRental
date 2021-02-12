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


namespace DataAccess.ConCreate
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
                return result.ToList();
            }
        }
    }
}

