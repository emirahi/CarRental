using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos
{
    public class UserDto:IDTO
    {
        public int UsersId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}
