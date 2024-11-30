﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class City
    {       
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Activo { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public int StateId { get; set; }
        public State State { get; set; } = new State();
    }
}
