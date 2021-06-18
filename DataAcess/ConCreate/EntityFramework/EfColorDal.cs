using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.ConCreate.EntityFramework;
using Entity.ConCreate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.ConCreate.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, CarProjectContext>, IColorDal
    {
        public List<CarByColorDto> GetByColorId(int colorId)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var query = from c in context.Cars
                            join color in context.Colors
                            on c.ColorId equals color.ColorId
                            join b in context.Brands
                            on c.BrandId equals b.BrandId
                            where c.ColorId == colorId
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
    }
}
