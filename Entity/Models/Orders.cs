using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Orders
    {
        public int Id { get; set; }     
        public DateOnly Date {  get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
        public bool Activo { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public int UsersId { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();
    }
}
