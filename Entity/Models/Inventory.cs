using Org.BouncyCastle.Crypto.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Inventory
    {
        public int Id { get; set; }        
        public string Size { get; set; }
        public string Color { get; set; }
        public int Stock {  get; set; }
        public string Location { get; set; }
        public int SKU { get; set; }
        public bool Activo { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();
    }
}
