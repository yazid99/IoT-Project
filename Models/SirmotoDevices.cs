using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace sirmoto
{
    public partial class SirmotoDevices
    {
        public SirmotoDevices()
        {
            SirmotoDeviceSchedule = new HashSet<SirmotoDeviceSchedule>();
        }
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("DeviceName")]
        public string DeviceName { get; set; }
        [JsonProperty("DeviceState")]
        public string DeviceState { get; set; }
        [JsonProperty("DeviceInfo")]
        public string DeviceInfo { get; set; }
        public DateTime LastUpdated {get; set;}
        [JsonProperty("UserId")]
        public string UserId { get; set; }
        [JsonIgnore] 
        public virtual AspNetUsers User { get; set; }
        public  virtual ICollection<SirmotoDeviceSchedule> SirmotoDeviceSchedule { get; set; }
    }
}
