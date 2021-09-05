using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TssCodingAssignment.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public float Cost { get; set; }
        public DateTime DateAdded { get; set; }
        public string ImageUrl { get; set; }

        public ProductModel()
        {
            Id = -1;
            Name = null;
            Description = null;
            Type = null;
            Quantity = -1;
            Cost = -1.00f;
            DateAdded = new DateTime();
            ImageUrl = null;
        }

        public ProductModel(int id, string name, string description, string type, int quantity, float cost, DateTime dateAdded, string imageUrl)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
            Quantity = quantity;
            Cost = cost;
            DateAdded = dateAdded;
            ImageUrl = imageUrl;
        }
    }
}