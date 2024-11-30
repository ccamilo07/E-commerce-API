﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public int SKU { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Stock { get; set; }
        public string Location { get; set; }
        public bool Activo  { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

    }
}
