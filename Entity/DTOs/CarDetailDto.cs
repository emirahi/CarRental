using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class CarDetailDto:IDTO
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public Decimal DailyPrice { get; set; }
        public string Descriptions { get; set; }
    }
}
