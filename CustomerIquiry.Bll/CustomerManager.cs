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

        public Customer GetCustomerWithTransactionByID(int? customerID)
        {
            return context.Customer
                            .Include(c => c.Transactions)
                            .Where(c => customerID == c.CustomerID)
                            .SingleOrDefault();
        }

        public Customer GetCustomerWithTransactionByEmail(string email)
        {
            return context.Customer
                            .Include(c => c.Transactions)
                            .Where(c => email == c.Email)
                            .SingleOrDefault();
        }

        public Customer GetCustomerWithTransaction(int? customerID, string email)
        {
            return context.Customer
                            .Include(c => c.Transactions)
                            .Where(c => (customerID == c.CustomerID)
                                        && (email == c.Email))
                            .SingleOrDefault();
        }
    }
}
