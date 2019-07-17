using ShopWebApi.Core;
using ShopWebApi.Persistence;
using ShopWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopWebApi.Controllers
{
    public class ProductController : ApiController
    {
        /// <summary>
        /// Unit of work
        /// </summary>
        UnitOfWork uow = new UnitOfWork();
        ProductService productService;
        public ProductController()
        {
             productService = new ProductService(uow);
        }

        /// <summary>
        /// Gets all Product from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            productService.GetAll();
            uow.Complete();
            return GetAll();
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            productService.Get(Id);
            uow.Complete();
            return Get(Id);
        }

        /// <summary>
        /// Adds new product to database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Add(Product product)
        {
            try
            {
                if (product.ItemName.StartsWith("!,@,#,$,%,^,&,*,(,)._.+,=,-,],[,',;,/,.,>,<,?,|,`.~"))
                {
                    throw new HttpResponseException(HttpStatusCode.NotModified);
                }
                else if (product.ItemPrice < 0)
                {
                    throw new HttpResponseException(HttpStatusCode.NotModified);
                }
                else
                {
                    var newproduct = new Product()
                    {
                        ItemName = product.ItemName,
                        ItemPrice = product.ItemPrice,
                        Description = product.Description,
                        Quantity = product.Quantity
                    };
                    productService.Add(newproduct);
                    uow.Complete();
                    var message = Request.CreateResponse(HttpStatusCode.Created, product);
                    message.Headers.Location = new Uri(Request.RequestUri +
                        product.ID.ToString());

                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /// <summary>
        /// Update a product with the give Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        [HttpPut]
        public void Update(int id, Product product)
        {
            if (product.ItemName.StartsWith("!,@,#,$,%,^,&,*,(,)._.+,=,-,],[,',;,/,.,>,<,?,|,`.~"))
            {
                throw new HttpResponseException(HttpStatusCode.NotModified);
            }
            else if (id < 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotModified);
            }
            else
            {
                //var product1 = uow.ProductRepository.Get(id);
                var newProduct = new Product()
                {
                        ItemName = product.ItemName,
                        ItemPrice = product.ItemPrice,
                        Quantity = product.Quantity,
                        Description = product.Description
                        
                };
                productService.Update(newProduct);
                uow.Complete();
            }
        }

        /// <summary>
        /// Deletes a product with an Id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {
                productService.Remove(id);
            }
            catch
            {

            }
        }
    }
}
