using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace sirmoto
{
    public partial class Companies
    {
        public Companies()
        {
            Employees = new HashSet<Employees>();
            Transactions = new HashSet<Transactions>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string PicturePath { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string State { get; set; }
        [JsonIgnore]
        public  virtual  AspNetUsers User { get; set; }
        [JsonIgnore]
        public virtual  ICollection<Employees> Employees { get; set; }
        [JsonIgnore]
        public virtual  ICollection<Transactions> Transactions { get; set; }

        public virtual  IEnumerable<Items> Items { get; set; }
    }
}
