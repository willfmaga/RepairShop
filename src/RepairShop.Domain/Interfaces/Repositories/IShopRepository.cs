﻿using RepairShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Domain.Interfaces.Repositories
{
    public interface IShopRepository
    {
        public IEnumerable<Shop> GetAll();

        public IEnumerable<Shop> GetName(string name);

        public IEnumerable<Shop> GetByDocument(string documentValue);


    }
}
