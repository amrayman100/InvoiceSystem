using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Collection.DSL;
using Collection.DAL;
using InvoiceSystem.ViewModel;

namespace InvoiceSystem.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        InvoiceDSL i = new InvoiceDSL();
        public ActionResult Index()
        {

            /*Customer c1 = new Customer { Cust_No = 1, Name = "el borg" };
            Customer c2 = new Customer { Cust_No = 2, Name = "alfa" };
            var invoices = new List<Invoice>
            {
               new Invoice{ID = 1 , Cust_ID = 1 , Act_CollectedDate = new DateTime(2017,2,8), Amount = 2000, Collected = true , Invoice_No = 12 , Suspended = false , CollectDate = new DateTime(2017,2,8), IssueDate = new DateTime(2017,2,8),Customer = c1},
               new Invoice{ID = 2 , Cust_ID = 2 , Act_CollectedDate = new DateTime(2017,2,8), Amount = 2000, Collected = true , Invoice_No = 13 , Suspended = false , CollectDate = new DateTime(2017,2,8), IssueDate = new DateTime(2017,2,8), Customer = c2},

            };*/
            return View(i.GetInvoices());
        }

        public ActionResult Search()
        {

            var invoices = i.GetInvoices();

            InvoiceViewModel v = new InvoiceViewModel { Invoices = invoices };

            return View(v);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Invoice invoice)
        {

            if (invoice != null)
            {
                i.InsertInvoice(invoice);
                i.CommitInvoices();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            if (id > 0)
            {
                i.Delete(id);
                i.CommitInvoices();
            }
            return RedirectToAction("Index");
        }
    }
        
}