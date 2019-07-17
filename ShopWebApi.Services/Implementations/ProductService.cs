using ShopWebApi.Core;
using ShopWebApi.Persistence;
using ShopWebApi.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApi.Services
{
    public class ProductService : IProductService
    {
        UnitOfWork uow = null; // new UnitOfWork();
        public ProductService(UnitOfWork _uow)
        {
            if (uow == null)
                uow = _uow;
        }

        public Product Get(int Id)
        {
            return uow.ProductRepository.Get(Id);
        }

        public List<Product> GetAll()
        {
            return uow.ProductRepository.GetAll().ToList();
        }

        public bool Add(Product product)
        {
            try
            {
                uow.ProductRepository.Add(product);
                uow.Complete();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public void Remove(int productID)
        {
            var product = uow.ProductRepository.Get(productID);
            if (product == null)
            {
                throw new Exception("Product Type not found");
            }
            else
            {
                uow.ProductRepository.Remove(product);
                uow.Complete();
            }
        }

        public void Update(Product product)
        {
            uow.ProductRepository.Update(product);
            uow.Complete(); 
        }
    }
}
