﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection.Repository;
using Collection.DAL;

namespace Collection.DSL
{
    public class InvoiceDSL
    {
        InvoiceRepo repo = new InvoiceRepo();
        public IEnumerable<Invoice> GetInvoices()
        {
            var list = repo.GetInvoices();
            return list;
        }
        public Invoice GetInvoiceByID(int id)
        {
            var invo = repo.GetInvoiceByID(id);
            return invo;
        }

        public void InsertInvoice(Invoice invo)
        {
            if (invo.Collected == true)
                invo.Act_CollectedDate = DateTime.Now;
            repo.InsertInvoice(invo);
        }

        public void Delete(int id)
        {
            repo.DeleteInvoice(id);

        }

        public void UpdateInvoice(Invoice invo)
        {
            if (invo.Collected == true && invo.Act_CollectedDate == null)
                invo.Act_CollectedDate = DateTime.Now;
            repo.UpdateInvoice(invo);
        }

        public void CommitInvoices()
        {
            repo.Commit();
        }
    }
}
