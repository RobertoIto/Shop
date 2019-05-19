using Shop.Core.Contracts;
using Shop.Core.Models;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        IRepository<Customer> customers;
        IBasketService basketService;
        IOrderService orderService;

        //public BasketController()
        //{
        //}

        public BasketController(IBasketService BasketService, 
                                IOrderService OrderService,
                                IRepository<Customer> Customers)
        {
            this.basketService = BasketService;
            this.orderService = OrderService;
            this.customers = Customers;
        }

        // GET: Basket
        public ActionResult Index()
        {
            var model = basketService.GetBasketItems(this.HttpContext);

            return View(model);
        }

        public ActionResult AddToBasket(string Id)
        {
            basketService.AddToBasket(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromBasket(string Id)
        {
            basketService.RemoveFromBasket(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public PartialViewResult BasketSummary()
        {
            var basketSummary = basketService.GetBasketSummary(this.HttpContext);

            return PartialView(basketSummary);
        }

        // The Authorize will verify if the user is logged in, if it is not then
        // redirect to the login page.
        [Authorize]
        public ActionResult Checkout()
        {
            // Get the customer from the database.
            Customer customer = 
                customers.Collection().FirstOrDefault(c => c.Email == User.Identity.Name);

            if (customer != null)
            {
                Order order = new Order()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    Street = customer.Street,
                    City = customer.City,
                    State = customer.State,
                    ZipCode = customer.ZipCode
                };

                return View(order);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Checkout(Order order)
        {
            var basketItems = basketService.GetBasketItems(this.HttpContext);
            order.OrderStatus = "Order Created.";

            // Get the email from the user login
            order.Email = User.Identity.Name;

            // process payment
            order.OrderStatus = "Payment in Progress.";

            order.OrderStatus = "Payment Processed.";
            orderService.CreateOrder(order, basketItems);
            basketService.ClearBasket(this.HttpContext);

            return RedirectToAction("Thankyou", new { OrderId = order.Id });
        }

        public ActionResult Thankyou(string OrderId)
        {
            ViewBag.OrderId = OrderId;
            return View();
        }
    }
}