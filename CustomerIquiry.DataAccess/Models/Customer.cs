using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerIquiry.DataAccess.Models
{
    public class Customer
    {
        [JsonProperty(PropertyName = "customerID")]
        public long CustomerID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "mobile")]
        public string MobileNumber { get; set; }

        [JsonProperty(PropertyName = "transactions")]
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
