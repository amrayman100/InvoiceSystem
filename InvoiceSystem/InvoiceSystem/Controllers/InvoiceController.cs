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
        CustomerDSL cust = new CustomerDSL();
        CommentDSL Com = new CommentDSL();
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
            Customer c1 = new Customer { Cust_No = 1, Name = "elborg" };
            Customer c2 = new Customer { Cust_No = 2, Name = "alfa" };
            var invoices = new List<Invoice>
           {
              new Invoice{ID = 1 , Cust_ID = 1 , Act_CollectedDate = new DateTime(2017,2,8), Amount = 2000, Collected = true , Invoice_No = 12 , Suspended = false , CollectDate = new DateTime(2017,2,8), IssueDate = new DateTime(2017,2,8),Customer = c1},
              new Invoice{ID = 2 , Cust_ID = 2 , Act_CollectedDate = new DateTime(2017,2,8), Amount = 2000, Collected = true , Invoice_No = 13 , Suspended = false , CollectDate = new DateTime(2017,2,8), IssueDate = new DateTime(2017,2,8), Customer = c2},

           };

            var customers = new List<Customer> { c1, c2 };

            InvoiceViewModel v = new InvoiceViewModel { Invoices = invoices, Customers = customers };

            return View(v);
        }


        [HttpGet]
        public ActionResult Add()
        {
            ViewData["Customer_List"] = cust.GetCustomers();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Invoice invoice, int ss)
        {

            if (invoice != null)
            {
                invoice.Cust_ID = ss;
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewData["Customer_List"] = cust.GetCustomers();
            return View(i.GetInvoiceByID(id));
        }

        [HttpPost]
        public ActionResult Edit(Invoice invoice)
        {
            if (invoice != null)
            {

                i.UpdateInvoice(invoice);
                i.CommitInvoices();
                return RedirectToAction("Index");
            }
            return View();
        }



        public string SearchResult(string IssueFrom, string IssueTo, string ColFrom, string ColTo, string Customer)
        {
            Customer c1 = new Customer { Cust_No = 1, Name = "elborg" };
            Customer c2 = new Customer { Cust_No = 2, Name = "alfa" };
            DateTime A = new DateTime(2018, 1, 1);
            var invoices = new List<Invoice>
           {

              new Invoice{ID = 1 , Cust_ID = 1 , Act_CollectedDate = A , Amount = 2000, Collected = true , Invoice_No = 12 , Suspended = false , CollectDate = A , IssueDate = A ,Customer = c1},
              new Invoice{ID = 2 , Cust_ID = 2 , Act_CollectedDate = A , Amount = 2000, Collected = true , Invoice_No = 13 , Suspended = false , CollectDate = A , IssueDate = A , Customer = c2},

           };


            var invoices2 = new List<Invoice>();

            DateTime IT = CreateDateTime(IssueTo);
            DateTime IF = CreateDateTime(IssueFrom);
            // DateTime CT = CreateDateTime(ColTo);
            // DateTime CF = CreateDateTime(ColFrom);

            if (Customer == "0")
            {
                foreach (var item in invoices)
                {

                    if (item.IssueDate >= IF && item.IssueDate <= IT)
                    {

                        invoices2.Add(item);
                    }


                }
            }

            else
            {
                foreach (var item in invoices)
                {

                    if (item.IssueDate >= IF && item.IssueDate <= IT && Customer == item.Customer.Name)
                    {

                        invoices2.Add(item);
                    }


                }

            }


            var a = Newtonsoft.Json.JsonConvert.SerializeObject(invoices2);

            return a;
        }



        public DateTime CreateDateTime(string a)
        {
            int year = Convert.ToInt32((a.Split('-'))[0]);
            int month = Convert.ToInt32((a.Split('-'))[1]);
            int day = Convert.ToInt32((a.Split('-'))[2]);

            DateTime A = new DateTime(year, month, day);
            return A;

        }


    }

}