using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.ConCreate
{
    public class Payment:IEntity
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public bool Success { get; set; }
    }
}
