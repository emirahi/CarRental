using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.ConCreate
{
    public class Customer:IEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        
    }
}
