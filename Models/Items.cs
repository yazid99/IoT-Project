using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace sirmoto
{
    public partial class Items 
    {
        public int Id { get; set; }
        public float Rating { get; set; }
        public int CompanyId {get; set;}
        public double Price {get; set;}
        public virtual Companies Company { get; set; }
        public virtual Products IdNavigation { get; set; }
    }
}
