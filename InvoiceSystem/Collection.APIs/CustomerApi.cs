using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Collection.DSL;
namespace Collection.APIs
{
    public class CustomerApi : ApiController
    {
        CustomerDSL c = new CustomerDSL();
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetAllCustomers()
        {

            return Ok(c.GetCustomers());
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult addCustomer()
        {
            if (!ModelState.IsValid)
            {

            }
            return Ok();
        }

    }
}
