using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerIquiry.DataAccess.Models
{
    public class Transaction
    {
        [JsonProperty(PropertyName = "id")]
        public int TransactionID { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public Decimal Amount { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonIgnore]
        public int CustomerID { get; set; }
    }
}
