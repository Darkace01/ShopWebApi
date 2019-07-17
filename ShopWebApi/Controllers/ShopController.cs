using ShopWebApi.Core;
using ShopWebApi.Persistence;
using ShopWebApi.Services;
using ShopWebApi.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopWebApi.Controllers
{
    public class ShopController : ApiController
    {
        UnitOfWork uow = new UnitOfWork();
        ShopService shopService;
        public ShopController()
        {
            shopService = new ShopService(uow);
        }


        /// <summary>
        /// Gets all shops in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        public HttpResponseMessage GetAll()
        {
            shopService.GetAll();
            uow.Complete();
            return GetAll();
        }

        /// <summary>
        /// Gets a shop with a particukar Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            shopService.Get(Id);
            uow.Complete();
            return Get(Id);
        }

        /// <summary>
        /// Adds a new shop
        /// </summary>
        /// <param name="shop"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Add(Shop shop)
        {
            try
            {
                if (shop.ShopName.StartsWith("!,@,#,$,%,^,&,*,(,)._.+,=,-,],[,',;,/,.,>,<,?,|,`.~"))
                {
                    throw new HttpResponseException(HttpStatusCode.NotModified);
                }
                else if (shop.ID < 0)
                {
                    throw new HttpResponseException(HttpStatusCode.NotModified);
                }
                else
                {
                    var newShop = new Shop()
                    {
                        ShopName = shop.ShopName,
                        Category = shop.Category,
                        TotalProduct = shop.TotalProduct
                    };
                    shopService.Add(newShop);
                    uow.Complete();
                    var message = Request.CreateResponse(HttpStatusCode.Created, shop);
                    message.Headers.Location = new Uri(Request.RequestUri +
                        shop.ID.ToString());

                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /// <summary>
        /// /Updates a partiicular shop
        /// </summary>
        /// <param name="id"></param>
        /// <param name="shop"></param>
        [HttpPut]
        public void Update(int id, [FromBody]Shop shop)
        {
            if (shop.ShopName.StartsWith("!,@,#,$,%,^,&,*,(,)._.+,=,-,],[,',;,/,.,>,<,?,|,`.~"))
            {
                throw new HttpResponseException(HttpStatusCode.NotModified);
            }
            else if (id < 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotModified);
            }
            else
            {

                var newShop = new Shop()
                {
                    ShopName = shop.ShopName,
                    Category = shop.Category,
                    TotalProduct = shop.TotalProduct

                };
                shopService.Update(newShop);
                uow.Complete();
            }
        }


        /// <summary>
        /// Deletes a shop with the given Id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {
                shopService.Remove(id);
            }
            catch
            {

            }
        }
    }
}
