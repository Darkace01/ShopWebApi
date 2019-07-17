using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopWebApi.Core
{
    public class Shop
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Item name is required")]
        public string ShopName { get; set; }
        [Required(ErrorMessage = "A category is required")]
        public double Category { get; set; }
        public int TotalProduct { get; set; }
        public virtual List<Product> Products { get; set; }
        public int ProductsId { get; set; }
    }
}