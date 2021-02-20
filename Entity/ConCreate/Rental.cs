using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.ConCreate
{
    public class Rental:IEntity
    {
        // RentalsId, CarId, CustomerId, RentDate,ReturnDate
        [Key]
        public int RentalsId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
