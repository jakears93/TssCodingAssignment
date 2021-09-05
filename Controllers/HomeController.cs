using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TssCodingAssignment.Models;
using TssCodingAssignment.Services.Business;

namespace TssCodingAssignment.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(UserModel userModel)
        {
            if (Session["totalItems"] == null)
            {
                Session["totalItems"] = 0;
            }
            ProductService productService = new ProductService();
            List<ProductModel> products = productService.GetAllProducts();

            return View("Index", products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AddToCart(string id)
        {
            ProductModel productModel = new ProductModel();
            int idValue = -1;

            try
            {
                idValue = Int32.Parse(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (idValue < 0)
            {
                return RedirectToAction("Index");
            }

            ProductService productService = new ProductService();
            productModel = productService.GetProductById(idValue);

            CartItemModel item = new CartItemModel { product = productModel, quantity = 1 , extendedCost = productModel.Cost};
            if (Session["cart"] == null)
            {
                List<CartItemModel> cart = new List<CartItemModel>();
                cart.Add(item);
                Session["cart"] = cart;
                Session["totalItems"] = 1;
            }
            else
            {
                List<CartItemModel> cart = (List<CartItemModel>)Session["cart"];
                int index = -1;
                foreach (CartItemModel cartItem in cart)
                {
                    if (cartItem.product.Id == idValue)
                    {
                        index = cart.IndexOf(cartItem);
                        break;
                    }
                }
                if (index != -1)
                {
                    cart[index].quantity++;
                    cart[index].extendedCost = cart[index].product.Cost * cart[index].quantity;
                }
                else
                {
                    cart.Add(item);
                }
                Session["cart"] = cart;
                int totalItems = (int)Session["totalItems"];
                totalItems++;
                Session["totalItems"] = totalItems;
            }

            return RedirectToAction("Index");
        }
    }
}