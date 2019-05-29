namespace CustomerIquiry.DataAccess.Migrations
{
    using CustomerIquiry.DataAccess.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CustomerIquiry.DataAccess.CustomerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CustomerIquiry.DataAccess.CustomerContext context)
        {
            context.Customer.AddOrUpdate(c => c.Email,
                new Customer()
                {
                    Email = "user@domain.com",
                    Name = "Firstname Lastname",
                    MobileNumber = "0123456789",
                    Transactions = new List<Transaction>() {
                        new Transaction() {
                            Date = new DateTime(2018, 2, 28, 21, 34, 0),
                            Amount = 1234.56m,
                            Currency = "USD",
                            Status = "Success",
                        },
                        new Transaction() {
                            Date = DateTime.Now,
                            Amount = 0.56m,
                            Currency = "THB",
                            Status = "Failed",
                        }
                    }
                },
                new Customer()
                {
                    Email = "user2@domain.com",
                    Name = "User Two",
                    MobileNumber = "2222222222",
                    Transactions = new List<Transaction>() {
                        new Transaction() {
                            Date = new DateTime(2018, 2, 28, 21, 34, 0),
                            Amount = 1234.56m,
                            Currency = "USD",
                            Status = "Success",
                        }
                    }
                },
                new Customer()
                {
                    Email = "user3@domain.com",
                    Name = "User Three",
                    MobileNumber = "3333333333"
                }
            );
        }
    }
}
