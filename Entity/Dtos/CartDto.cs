using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class CartDto
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public bool Activo { get; set; }
        public int UserId  { get; set; }
        public int ProductId { get; set; }
        public string ProductName  { get; set; }

    }
}
