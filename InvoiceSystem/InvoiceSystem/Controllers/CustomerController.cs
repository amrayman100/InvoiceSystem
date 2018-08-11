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
            var list = cust.GetCustomers();
            return View(list);
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
                cust.CommitCustomers();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            if (id > 0)
            {
                cust.Delete(id);
                cust.CommitCustomers();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(cust.GetCustomerByID(id));
        }

        [HttpPost]
        public ActionResult Edit(Customer c)
        {
            if (c != null)
            {
                cust.UpdateCustomer(c);
                cust.CommitCustomers();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}