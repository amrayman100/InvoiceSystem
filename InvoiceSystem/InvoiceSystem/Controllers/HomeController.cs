using InvoiceSystem.Models;
using InvoiceSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceSystem.Controllers
{

    public class HomeController : Controller
    {
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

            var invoices = new List<DummyInvoice>
            {
               new DummyInvoice{InvoiceNo = 1 , IssueDate = "2/2/2015" , CollectionDate = "2/9/2015",ActualCollDate = "2/10/2015", Customer = "alfa lab", Amount = 1000 },
               new DummyInvoice{InvoiceNo = 2 , IssueDate = "5/8/2018" , CollectionDate = "10/10/2018",ActualCollDate = "10/10/2018", Customer = "el borg", Amount = 200 }

            };

            InvoiceViewModel v = new InvoiceViewModel
            {
                Invoices = invoices
            };

            return View(v);
        }

        public ActionResult Setup()
        {
           

            return View();
        }


        public ActionResult Reports()
        {
           

            return View();
        }




    }
}