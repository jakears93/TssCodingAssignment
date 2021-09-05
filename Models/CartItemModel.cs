using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TssCodingAssignment.Models
{
    public class CartItemModel
    {
        public ProductModel product { get; set; }
        public int quantity { get; set; }
        public float extendedCost { get; set; }
    }
}