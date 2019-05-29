using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerIquiry.DataAccess.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime Date { get; set; }
        public Decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public int CustomerID { get; set; }
    }
}
