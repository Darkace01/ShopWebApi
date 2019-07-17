using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ShopWebApi.Core;
namespace ShopWebApi.Persistence
{
    public class ShopWebApi : DbContext
    {
        public ShopWebApi()
            : base("name=ShopWebApi")
        {
        }

        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}