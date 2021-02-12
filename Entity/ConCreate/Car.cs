using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.ConCreate
{
    public class Car: IEntity
    {
        // Id, BrandId, ColorId, ModelYear, DailyPrice, Description
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public Decimal DailyPrice { get; set; }
        public string Descriptions { get; set; }
    }
}
