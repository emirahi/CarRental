using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.ConCreate
{
    public class CarImages: IEntity
    {
        //CarImages(Araba Resimleri) tablosu oluşturunuz. (Id, CarId, ImagePath, Date) Bir arabanın birden fazla resmi olabilir.
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Datee { get; set; }
    }
}
