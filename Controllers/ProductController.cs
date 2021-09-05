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
            ProductModel product = productService.GetProduct(id);

            return View("Catalog", product);
        }
    }
}