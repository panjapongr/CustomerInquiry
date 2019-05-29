using CustomerIquiry.DataAccess;
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
        public Customer GetCustomerWithTransaction(int? customerID = null, string email = null)
        {
            var customer = context.Customer
                            .Include(c => c.Transactions)
                            .Where(c => (customerID == null || customerID == c.CustomerID)
                                        && (email == null || email == c.Email))
                            .SingleOrDefault();
            if (customer.Transactions.Count > 5)
            {
                customer.Transactions = customer.Transactions.OrderByDescending(t => t.Date).Take(5).ToList();
            }
            return customer;
        }
    }
}
