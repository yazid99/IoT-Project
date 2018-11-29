using System;
using System.Collections.Generic;

namespace sirmoto
{
    public partial class ProductsPictures
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int ProductId { get; set; }

        public virtual Products Product { get; set; }
    }
}
