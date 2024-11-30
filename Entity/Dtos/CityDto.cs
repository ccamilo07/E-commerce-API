using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Activo { get; set; }
        public int StateId  { get; set; }
        public string StateName { get; set; }
    }
}
