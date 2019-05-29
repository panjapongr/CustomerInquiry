using CustomerIquiry.DataAccess;
using CustomerIquiry.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomerInquiry.Api.Controllers
{
    public class CustomerController : ApiController
    {
        public Customer Get(int customerID, string email)
        {
            return new CustomerContext().Customer
                            .Where(c => customerID == c.CustomerID && email == c.Email)
                            .SingleOrDefault();
        }
    }
}
