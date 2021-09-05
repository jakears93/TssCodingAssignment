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
    }
}