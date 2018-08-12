using InvoiceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Collection.DAL;

namespace InvoiceSystem.ViewModel
{
    public class InvoiceViewModel
    {
        public IEnumerable<Invoice> Invoices { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}