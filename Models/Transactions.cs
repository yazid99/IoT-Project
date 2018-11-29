using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace sirmoto
{
    public partial class Transactions
    {
        public Transactions()
        {
            PickedUpEmployees = new HashSet<PickedUpEmployees>();
            PickedUpProducts = new HashSet<PickedUpProducts>();
        }
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CompanyId { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string PaymentMethod { get; set; }
        public float Discount { get; set; }
        public DateTime TimeStamp { get; set; }
        public double Total {get; set;}
        [JsonIgnore] 
        public virtual Companies Company { get; set; }
        [JsonIgnore] 
        
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<PickedUpEmployees> PickedUpEmployees { get; set; }
        public virtual ICollection<PickedUpProducts> PickedUpProducts { get; set; }
    }
}
