using InvoiceSystem.Models;
using InvoiceSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Collection.DSL;
using Collection.DAL;


namespace InvoiceSystem.Controllers
{

    public class HomeController : Controller
    {
        CustomerDSL cust = new CustomerDSL();
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Invoice()
        {

            var invoices = new List<Invoice>
            {
               new Invoice(),
               new Invoice()

            };

            InvoiceViewModel v = new InvoiceViewModel
            {
                Invoices = invoices
            };

            return View(v);
        }

       

        public ActionResult Reports()
        {
           

            return View();
        }

        public ActionResult EditInvoice(int id)
        {
            return View(id);
        }




    }
}