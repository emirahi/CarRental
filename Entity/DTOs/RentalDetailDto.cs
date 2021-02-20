using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class RentalDetailDto:IDTO
    {
        public int RentalsId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
