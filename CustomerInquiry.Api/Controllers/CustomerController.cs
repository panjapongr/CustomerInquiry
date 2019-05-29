using CustomerIquiry.Bll;
using CustomerIquiry.DataAccess;
using CustomerIquiry.DataAccess.Models;
using Newtonsoft.Json;
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

        public Customer Get(string customerID = null, string email = null)
        {
            ValidateGetCustomerRequest(customerID, email);
            try
            {
                long? validCustomerID = ToNullableLong(customerID);
                var customer = customerManager.GetCustomerWithTransaction(validCustomerID, email);
                if (customer == null)
                {
                    throw HttpNotFound();
                }
                return customer;
            }
            catch (HttpResponseException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw HttpBadRequest();
            }
        }

        private void ValidateGetCustomerRequest(string customerID, string email)
        {
            if (customerID == null && email == null)
            {
                throw HttpBadRequest("No inquiry criteria");
            }
            if (!IsValidCustomerID(customerID))
            {
                throw HttpBadRequest("Invalid Customer ID");
            }
            if (!IsValidEmail(email))
            {
                throw HttpBadRequest("Invalid Email");
            }
        }

        private static bool IsValidCustomerID(string customerID)
        {
            // Valid if null or can convert to int
            return customerID == null || (customerID.Length <= 10 && long.TryParse(customerID, out long id));
        }

        private static bool IsValidEmail(string email)
        {
            if (email == null)
            {
                return true;
            }
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return email.Length<= 25 && mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private HttpResponseException HttpBadRequest(string message = null)
        {
            if (string.IsNullOrEmpty(message))
            {
                return new HttpResponseException(HttpStatusCode.BadRequest);
            }

            HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, message);
            return new HttpResponseException(response);
        }

        private HttpResponseException HttpNotFound(string message = null)
        {
            if (string.IsNullOrEmpty(message))
            {
                return new HttpResponseException(HttpStatusCode.NotFound);
            }

            HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            return new HttpResponseException(response);
        }


        public static long? ToNullableLong(string text)
        {
            if (long.TryParse(text, out long value))
            {
                return value;
            }
            return null;
        }
    }
}
