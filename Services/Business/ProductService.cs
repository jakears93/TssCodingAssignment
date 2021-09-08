using TssCodingAssignment.Models;
using TssCodingAssignment.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TssCodingAssignment.Services.Business
{
    public class ProductService
    {
        ProductDAO daoService = new ProductDAO();

        public List<Models.ProductModel> GetAllProducts()
        {
            return daoService.PopulateList();
        }

        public ProductModel GetProductById(int id)
        {
            return daoService.GetProductById(id);
        }

        public ProductModel GetProductByName(string name)
        {
            return daoService.GetProductByName(name);
        }

        public int AddProduct(ProductModel product)
        {
            return daoService.AddProduct(product);
        }

        public int EditProduct(ProductModel product)
        {
            return daoService.EditProduct(product);
        }

        public int RemoveProduct(ProductModel product)
        {
            return daoService.RemoveProduct(product);
        }
    }
}