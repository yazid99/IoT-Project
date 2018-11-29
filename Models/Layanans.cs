using System;
using System.Collections.Generic;

namespace sirmoto
{
    public partial class Layanans 
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Hit { get; set; }

        public virtual  Products IdNavigation { get; set; }
    }
}
