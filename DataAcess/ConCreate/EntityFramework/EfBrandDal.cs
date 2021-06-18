
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.ConCreate;
using Entity.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.ConCreate.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarProjectContext>, IBrandDal
    {
        public List<CarByBrandDto> GetByBrandId(int brandId)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var query = from b in context.Brands
                            join c in context.Cars
                            on b.BrandId equals c.BrandId
                            join color in context.Colors
                            on c.ColorId equals color.ColorId
                            where c.BrandId == brandId
                            select new CarByBrandDto
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
    }
}
