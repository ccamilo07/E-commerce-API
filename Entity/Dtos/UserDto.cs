using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address  { get; set; }
        public string City { get; set; }
        public bool Activo { get; set; }
        public int CityId { get; set; }
        public string Cityname { get; set; }

    }
}
