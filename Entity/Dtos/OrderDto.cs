using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
        public bool Activo { get; set; }
        public int UsersId { get; set; }
        public string UserName { get; set; }

    }
}
