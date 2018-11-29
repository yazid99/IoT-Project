using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace sirmoto
{
    public partial class SirmotoDeviceSchedule
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public TimeSpan Time { get; set; }
        public TimeSpan Duration { get; set; }
        [JsonIgnore] 
        public virtual SirmotoDevices Device { get; set; }
    }
}
