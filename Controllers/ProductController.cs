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
        public ActionResult Catalog(int id = -255)
        {
            ProductService productService = new ProductService();
            ProductModel product = productService.GetProductById(id);

            if (product.Id > 0)
            {
                return View("Catalog", product);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Modify()
        {
            if(Session["user"] == "Admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult AddProduct(ProductModel productModel)
        {
            ProductService productService = new ProductService();
            ProductModel testProduct = productService.GetProductByName(productModel.Name);
            if(testProduct.Id < 0)
            {
                productModel.DateAdded = DateTime.Now;
                if (productService.AddProduct(productModel) == 1)
                {
                    TempData["alertMessage"] = "Successfully Added Product";
                    Console.WriteLine("Successfully Added Product");
                }
                else
                {
                    TempData["alertMessage"] = "Failed to Add Product";
                    Console.WriteLine("Failure to Add Product");
                }
            }
            else
            {
                TempData["alertMessage"] = "Product Already Exists";
                Console.WriteLine("Product Already Exists.");
            }
            return RedirectToAction("Modify", "Product");
        }

        public ActionResult EditProduct(ProductModel productModel)
        {
            ProductService productService = new ProductService();
            ProductModel product = null;
            product = productService.GetProductById(productModel.Id);
            if (product.Id < 0)
            {
                product = productService.GetProductByName(productModel.Name);
            }

            if (product.Id > 0)
            {
                product.DateAdded = DateTime.Now;

                if(productModel.Name != null)
                {
                    product.Name = productModel.Name;
                }
                if (productModel.Description != null)
                {
                    product.Description = productModel.Description;
                }
                if (productModel.Type != null)
                {
                    product.Type = productModel.Type;
                }
                if (productModel.Quantity != -255)
                {
                    product.Quantity = productModel.Quantity;
                }
                if (productModel.Cost != -255.0f)
                {
                    product.Cost = productModel.Cost;
                }
                if (productModel.ImageUrl != null)
                {
                    product.ImageUrl = productModel.ImageUrl;
                }

                if (productService.EditProduct(product) == 1)
                {
                    TempData["alertMessage"] = "Successfully Editted Product";
                    Console.WriteLine("Successfully Eddited Product");
                }
                else
                {
                    TempData["alertMessage"] = "Failed to Edit Product";
                    Console.WriteLine("Failure to Edit Product");
                }
            }
            else
            {
                TempData["alertMessage"] = "Product Does Not Exist";
                Console.WriteLine("Product Does Not Exist.");
            }
            return RedirectToAction("Modify", "Product");
        }

        public ActionResult RemoveProduct(ProductModel productModel)
        {
            ProductService productService = new ProductService();
            ProductModel product = productService.GetProductById(productModel.Id);
            if (product != null)
            {
                if (productService.RemoveProduct(product) == 1)
                {
                    TempData["alertMessage"] = "Successfully Removed Product";
                    Console.WriteLine("Successfully Removed Product");
                }
                else
                {
                    TempData["alertMessage"] = "Failed to Remove Product";
                    Console.WriteLine("Failure to Removed Product");
                }
            }
            else
            {
                TempData["alertMessage"] = "Product Does Not Exist";
                Console.WriteLine("Product Does Not Exist.");
            }
            return RedirectToAction("Modify", "Product");
        }
    }
}