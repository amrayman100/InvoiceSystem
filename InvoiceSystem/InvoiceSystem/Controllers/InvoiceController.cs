using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Collection.DSL;
using Collection.DAL;
using InvoiceSystem.ViewModel;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace InvoiceSystem.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        InvoiceDSL i = new InvoiceDSL();
        CustomerDSL c = new CustomerDSL();
        CommentDSL comment = new CommentDSL();

        public ActionResult Index()
        {

            /*Customer c1 = new Customer { Cust_No = 1, Name = "el borg" };
            Customer c2 = new Customer { Cust_No = 2, Name = "alfa" };
            var invoices = new List<Invoice>
            {
               new Invoice{ID = 1 , Cust_ID = 1 , Act_CollectedDate = new DateTime(2017,2,8), Amount = 2000, Collected = true , Invoice_No = 12 , Suspended = false , CollectDate = new DateTime(2017,2,8), IssueDate = new DateTime(2017,2,8),Customer = c1},
               new Invoice{ID = 2 , Cust_ID = 2 , Act_CollectedDate = new DateTime(2017,2,8), Amount = 2000, Collected = true , Invoice_No = 13 , Suspended = false , CollectDate = new DateTime(2017,2,8), IssueDate = new DateTime(2017,2,8), Customer = c2},

            };*/
            var list = comment.GetComments();
            ViewData["CommentList"] = list;
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
            var list1 = i.GetInvoices();
            var list2 = c.GetCustomers();
            var customers = new List<Customer> { c1, c2 };

            InvoiceViewModel v = new InvoiceViewModel { Invoices = list1, Customers = list2 };

            var list = comment.GetComments();
            ViewData["CommentList"] = list;

            return View(v);
        }
        [HttpGet]
        public ActionResult Add()
        {
            var list = c.GetCustomers();
            ViewData["Customer_List"] = list;
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
        public string SearchResult(string IssueFrom, string IssueTo, string ColFrom, string ColTo, string Customer)
        {
            DateTime IT = CreateDateTime(IssueTo);
            DateTime IF = CreateDateTime(IssueFrom);
            Customer c1 = new Customer { Cust_No = 1, Name = "elborg" };
            Customer c2 = new Customer { Cust_No = 2, Name = "alfa" };
            DateTime A = new DateTime(2018, 1, 1);

            var list1 = i.GetInvoices();

            var invoices2 = new List<Invoice>();

            if (Customer == "0")
            {
                foreach (var item in list1)
                {
                    if (item.IssueDate >= IF && item.IssueDate <= IT)
                    {

                        invoices2.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in list1)
                {
                    if (item.IssueDate >= IF && item.IssueDate <= IT && Customer == item.Customer.Name)
                    {

                        invoices2.Add(item);
                    }
                }
            }
            //var a = Newtonsoft.Json.JsonConvert.SerializeObject(invoices2);
            var a = JsonConvert.SerializeObject(invoices2, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var list = comment.GetComments();
            ViewData["CommentList"] = list;
            ViewData["Customer_List"] = c.GetCustomers();
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
        public ActionResult DeleteComment(int id)
        {

            if (id > 0)
            {
                comment.DeleteComment(id);
                comment.Commit();
            }
            return RedirectToAction("Index");
        }
        public string addComment(string InvoiceId, string Comment)
        {
            string userid = Session["UserID"].ToString();
            Comment c = new Comment();
            c.Comment1 = Comment;
            c.User_ID = Convert.ToInt32(userid);
            c.Invoice_ID = Convert.ToInt32(InvoiceId);
            comment.InsertComment(c);
            comment.Commit();

            var comments = comment.GetComments();

            var comments2 = new List<Comment>();

            foreach (var item in comments)
            {
                if (item.Invoice_ID == Convert.ToInt32(InvoiceId))
                {
                    comments2.Add(item);

                }
            }
            var a = JsonConvert.SerializeObject(comments2, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            return a;
        }
        public string fillTable(string InvoiceId)
        {
            var comments = comment.GetComments();
            var comments2 = new List<Comment>();
            foreach (var item in comments)
            {
                if (item.Invoice_ID == Convert.ToInt32(InvoiceId))
                {
                    comments2.Add(item);
                }
            }
            var a = JsonConvert.SerializeObject(comments2, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            return a;
        }
    }
}
