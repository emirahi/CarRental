using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.ConCreate
{
    public class Card:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CreditCard { get; set; }
        public string Cvv { get; set; }
    }
}
