using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection.DAL;
using System.Data.Entity;

namespace Collection.Repository
{
    public class CustomerRepo
    {
        private invoicesystemEntities context;
        public CustomerRepo()
        {
            context = new invoicesystemEntities();
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }
        public Customer GetCustomerByID(int id)
        {
            return context.Customers.Find(id);
        }

        public void InsertCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            
        }

        public void DeleteCustomer(int id)
        {
            Customer customer = context.Customers.Find(id);
            context.Customers.Remove(customer);
            
        }

        public void UpdateCustomer(Customer customer)
        {
            context.Entry(customer).State = EntityState.Modified;
           
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
