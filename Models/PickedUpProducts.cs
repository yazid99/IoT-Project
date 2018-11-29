using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace sirmoto
{
    public partial class PickedUpProducts
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int TransactionId { get; set; }
        [JsonIgnore] 
        public virtual  Products Product { get; set; }
        [JsonIgnore] 
        public virtual  Transactions Transaction { get; set; }
    }
}
