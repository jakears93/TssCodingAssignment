using TssCodingAssignment.Models;
using TssCodingAssignment.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TssCodingAssignment.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Catalog(int id)
        {
            ProductService productService = new ProductService();
            ProductModel product = productService.GetProductById(id);

            return View("Catalog", product);
        }

        public ActionResult AddProduct(ProductModel product)
        {
            ProductService productService = new ProductService();
            ProductModel newProduct = productService.GetProductByName(product.Name);
            if(newProduct == null)
            {
                product.DateAdded = DateTime.Now;
                if(productService.AddProduct(product))
                {
                    Console.WriteLine("Successfully Added Product");
                }
                else
                {
                    Console.WriteLine("Failure to Add Product");
                }
            }
            else
            {
                Console.WriteLine("Product Already Exists.");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}