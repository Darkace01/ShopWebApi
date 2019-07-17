using ShopWebApi.Core;
using ShopWebApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopWebApi.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ShopWebApi context)
            : base(context)
        {
        }
    }
}