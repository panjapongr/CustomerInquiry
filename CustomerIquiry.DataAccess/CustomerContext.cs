using CustomerIquiry.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerIquiry.DataAccess
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        public CustomerContext() : base("CustomerInquiryDBConnection")
        {
        }

        public CustomerContext(string connectionString) : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().Property(e => e.Amount).HasPrecision(12, 2);
        }
    }
}
