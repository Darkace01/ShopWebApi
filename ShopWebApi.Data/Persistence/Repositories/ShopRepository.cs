using ShopWebApi.Core;
using ShopWebApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopWebApi.Persistence.Repositories
{
    public class ShopRepository : Repository<Shop>, IShopRepository
    {
        public ShopRepository(ShopWebApi context)
            : base(context)
        {
        }


    }
}