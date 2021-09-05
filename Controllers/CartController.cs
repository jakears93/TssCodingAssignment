using TssCodingAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TssCodingAssignment.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            List<CartItemModel> cart = new List<CartItemModel>();
            if (Session["cart"] != null)
            {
                cart = (List<CartItemModel>)Session["cart"];
            }

            return View("Cart", cart);
        }

        public ActionResult Remove(string Id)
        {
            int id = Int32.Parse(Id);
            List<CartItemModel> cart = new List<CartItemModel>();
            if (Session["cart"] != null)
            {
                cart = (List<CartItemModel>)Session["cart"];
            }

            int totalItems = (int)Session["totalItems"];

            foreach (var item in cart)
            {
                if(id == item.product.Id)
                {
                    if(item.quantity > 1)
                    {
                        item.quantity--;
                        item.extendedCost = item.product.Cost * item.quantity;
                    }
                    else
                    {
                        cart.Remove(item);
                    }
                    totalItems--;
                    Session["totalItems"] = totalItems;
                    Session["cart"] = cart;
                    break;
                }
            }

            return RedirectToAction("Index");
        }
    }
}