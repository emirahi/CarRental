using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class CarSearchDto:IDTO
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public Decimal DailyPrice { get; set; }
        public string Descriptions { get; set; }
    }
}
