using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class RentalOfCar:IDTO
    {
        public int RentalsId { get; set; }
        public int CarId { get; set; }
        public string userName { get; set; }
        public string brandName { get; set; }
        public string colorName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}

