using CustomerIquiry.Bll;
using CustomerIquiry.DataAccess;
using CustomerIquiry.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomerInquiry.Api.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly CustomerManager customerManager = new CustomerManager(new CustomerContext(ConfigurationManager.ConnectionStrings["CustomerInquiryDBConnection"].ConnectionString));

        public Customer Get(int? customerID = null, string email = null)
        {
            ValidateGetCustomerRequest(customerID, email);
            try
            {
                return customerManager.GetCustomerWithTransaction(customerID, email);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        private void ValidateGetCustomerRequest(int? customerID, string email)
        {
        }
    }
}
