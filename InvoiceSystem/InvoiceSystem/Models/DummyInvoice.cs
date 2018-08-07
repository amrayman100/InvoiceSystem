using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceSystem.Models
{
    public class DummyInvoice
    {
        public int InvoiceNo { get; set; }
        public String IssueDate { get; set; }
        public String CollectionDate { get; set; }
        public String ActualCollDate { get; set; }
        public String Customer { get; set; }
        public float Amount { get; set; }
        public bool Collected { get; set; }
        public bool Suspended { get; set; }


        public DummyInvoice()
        {
            Collected = false;
            Suspended = false;
        }



    }
}