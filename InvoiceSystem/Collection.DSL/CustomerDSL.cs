using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection.Repository;
using Collection.DAL;

namespace Collection.DSL
{
   
    public class CustomerDSL
    {
        CustomerRepo repo = new CustomerRepo();
        public IEnumerable<Customer> GetCustomers()
        {
            var list = repo.GetCustomers();
            return list;
        }
        public Customer GetCustomerByID(int id)
        {
            var customer = repo.GetCustomerByID(id);
            return customer;
        }

        public void InsertCustomer(Customer customer)
        {
            var list = repo.GetCustomers();
            int cnt = list.Count();
            foreach(var i in list)
            {
                if (i.Cust_No >= cnt)
                    cnt = (int)i.Cust_No + 1;
            }
            customer.Cust_No = cnt;
            repo.InsertCustomer(customer);
        }
        public void Delete(int id)
        {
            repo.DeleteCustomer(id);

        }

        public void UpdateCustomer(Customer customer)
        {
            repo.UpdateCustomer(customer);
        }

        public void CommitCustomers()
        {
            repo.Commit();
        }
    }
}
