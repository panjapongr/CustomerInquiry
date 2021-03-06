﻿using CustomerIquiry.DataAccess;
using CustomerIquiry.DataAccess.Models;
using System.Data.Entity;
using System.Linq;

namespace CustomerIquiry.Bll
{
    public class CustomerManager
    {
        private readonly CustomerContext context;

        public CustomerManager(CustomerContext customerContext)
        {
            context = customerContext;
        }

        /// <summary>
        ///     Search DB for customer data and related transaction data by Customer ID, Email or Both
        /// </summary>
        /// <param name="customerID">Customer ID</param>
        /// <param name="email">Customer Email</param>
        /// <returns>Return Customer and related transaction</returns>
        public Customer GetCustomerWithTransaction(long? customerID = null, string email = null)
        {
            var customer = context.Customer
                            .Where(c => (customerID == null || customerID == c.CustomerID)
                                        && (email == null || email == c.Email))
                            .SingleOrDefault();
            if (customer != null)
            {
                context.Entry(customer)
                        .Collection(c => c.Transactions)
                        .Query()
                        .OrderByDescending(t => t.Date)
                        .Take(5)
                        .Load();
            }
            return customer;
        }
    }
}
