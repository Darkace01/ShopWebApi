using ShopWebApi.Core;
using ShopWebApi.Persistence;
using ShopWebApi.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApi.Services.Implementations
{
    public class ShopService : IShopService
    {
        UnitOfWork uow = null; // new UnitOfWork();
        public ShopService(UnitOfWork _uow)
        {
            if (uow == null)
                uow = _uow;
        }

        public Shop Get(int Id)
        {
            return uow.ShopRepository.Get(Id);
        }

        public List<Shop> GetAll()
        {
            return uow.ShopRepository.GetAll().ToList();
        }

        public bool Add(Shop shop)
        {
            try
            {
                uow.ShopRepository.Add(shop);
                uow.Complete();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Remove(int shopID)
        {
            var product = uow.ShopRepository.Get(shopID);
            if (product == null)
            {
                throw new Exception("Product Type not found");
            }
            else
            {
                uow.ShopRepository.Remove(product);
                uow.Complete();
               
            }
        }

        public void Update(Shop shop)
        {
            uow.ShopRepository.Update(shop);
            uow.Complete(); ;
        }
    }
}
