using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection.DAL;
using System.Data.Entity;

namespace Collection.Repository
{
    public class InvoiceRepo
    {
        private invoicesystemEntities context;
        public InvoiceRepo()
        {
            context = new invoicesystemEntities();
        }
        public IEnumerable<Invoice> GetInvoices()
        {
            return context.Invoices.ToList();
        }
        public Invoice GetInvoiceByID(int id)
        {
            return context.Invoices.Find(id);
        }

        public void InsertInvoice(Invoice invoice)
        {
            context.Invoices.Add(invoice);

        }

        public void DeleteInvoice(int id)
        {
            Invoice invo = context.Invoices.Find(id);
            context.Invoices.Remove(invo);

        }

        public void UpdateInvoice(Invoice invo)
        {
            context.Entry(invo).State = EntityState.Modified;

        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
