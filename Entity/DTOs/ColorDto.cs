using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class ColorDto:IDTO
    {
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public int CarId { get; set; }
        public string ColorName { get; set; }
        public string ModelYear { get; set; }
        public string DailyPrice { get; set; }
        public string Descriptions { get; set; }
        public string BrandName { get; set; }

    }
}
