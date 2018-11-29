using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace sirmoto
{
    public partial class Products
    {
        public Products()
        {
            PickedUpProducts = new HashSet<PickedUpProducts>();
            ProductsPictures = new HashSet<ProductsPictures>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Descriptions { get; set; }
        public uint RequiredWorker { get; set; }
        public int HitCount { get; set; }

        public virtual  Items Items { get; set; }
        public virtual  Layanans Layanans { get; set; }
        [JsonIgnore]
        public virtual  ICollection<PickedUpProducts> PickedUpProducts { get; set; }
        public  virtual ICollection<ProductsPictures> ProductsPictures { get; set; }
    }
}
