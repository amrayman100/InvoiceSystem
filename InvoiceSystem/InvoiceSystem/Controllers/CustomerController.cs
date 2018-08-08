using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Collection.DSL;
using Collection.DAL;

namespace InvoiceSystem.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        CustomerDSL cust = new CustomerDSL();
        public ActionResult Index()
        {
           
            return View(cust.GetCustomers());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Customer c)
        {

            if (c != null)
            {
                cust.InsertCustomer(c);
            }
            return View();
        }
    }
}