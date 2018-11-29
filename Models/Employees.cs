using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace sirmoto
{
    public partial class Employees
    {
        public Employees()
        {
            PickedUpEmployees = new HashSet<PickedUpEmployees>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string UserId { get; set; }
        public string State { get; set; }
        public decimal Rating { get; set; }
        public string PicturePath { get; set; }
        public string Location { get; set; }

        public virtual  Companies Company { get; set; }
        [JsonIgnore]
        public virtual  AspNetUsers User { get; set; }
        public virtual  ICollection<PickedUpEmployees> PickedUpEmployees { get; set; }
    }
}
