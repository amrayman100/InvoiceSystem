using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Collection.DSL;
using Collection.DAL;
using System.Net.Http;
using System.Net;

namespace Collection.APIs
    
{
    [AllowAnonymous]
    [RoutePrefix("CustomerAPI/Customers")]
    public class CustomerApi : ApiController
    {
        CustomerDSL c = new CustomerDSL();
        [System.Web.Http.HttpGet]
        [AllowAnonymous]
        [Route("GetAllCustomers")]
        public IHttpActionResult GetAllCustomers()
        {

            return Ok(c.GetCustomers());
        }

        [System.Web.Http.HttpPost]
        [Route("addCustomer")]
        public HttpResponseMessage addCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            c.InsertCustomer(customer);
            c.CommitCustomers();
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
