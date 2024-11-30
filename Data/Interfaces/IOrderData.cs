﻿using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IOrderData
    {
      
        Task<IEnumerable<Orders>> GetAll();
        Task<Orders> GetById(int id);
        Task update(Orders order);
        Task<Orders> Save(Orders order);

    }
}
