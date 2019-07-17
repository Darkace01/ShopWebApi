using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopWebApi.Core
{
    public class Product
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Item name is required")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Price name is required")]
        public double ItemPrice { get; set; }
        [Required(ErrorMessage = "Quantity name is required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Description name is required")]
        public string Description { get; set; }
        public virtual Shop Shop { get; set; }
    }
}