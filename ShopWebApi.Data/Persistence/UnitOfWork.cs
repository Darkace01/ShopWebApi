using ShopWebApi.Core;
using ShopWebApi.Core.Repositories;
using ShopWebApi.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopWebApi.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ShopWebApi _context = new ShopWebApi();

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        private ShopRepository shopRepository;
        public ShopRepository ShopRepository
        {
            get
            {
                if (shopRepository == null)
                    shopRepository = new ShopRepository(_context);
                return shopRepository;
            }
        }

        private ProductRepository productRepository;
        public ProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(_context);
                return productRepository;
            }
        }
    }
}