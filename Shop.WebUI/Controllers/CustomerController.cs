using Shop.Core.Contracts;
using Shop.Core.Models;
using Shop.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        IRepository<Customer> customers;

        public CustomerController(IRepository<Customer> Customers)
        {
            this.customers = Customers;
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult CustormerFirstNamePartialView()
        {
            // Get the customer from the database.
            Customer cust = new Customer();

            //cust = httpContext.customers.GetUserName();
            if (customers != null)
            {
                cust = customers.Collection().FirstOrDefault(c => c.Email == User.Identity.Name);
            }

            return PartialView(cust);
        }        
    }
}