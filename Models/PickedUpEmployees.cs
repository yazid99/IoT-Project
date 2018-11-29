using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace sirmoto
{
    public partial class PickedUpEmployees
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TransactionId { get; set; }
        [JsonIgnore] 
        public virtual  Employees Employee { get; set; }
        [JsonIgnore] 
        public virtual  Transactions Transaction { get; set; }
    }
}
