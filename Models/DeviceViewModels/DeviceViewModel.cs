using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sirmoto.Models.DeviceViewModels
{
    public class DeviceViewModel
    {
        [Required]
        [Display(Name = "Device Name")]
        public string Device { get; set; }

        [Display(Name = "Description")]
        public string DescriptionJSON { get; set; }
        [Required]
        [Display(Name = "Operation Mode")]
        public string OperationModeJSON { get; set; }

        [Display(Name = "Width")]
        [Range(0, 999.99)]
        public decimal LandsizeXJSON { get; set; }

        [Display(Name = "Height")]
        [Range(0, 999.99)]
        public decimal LandsizeYJSON { get; set; }


        [Display(Name = "Town (for weather)")]
        public string LocationJSON { get; set; }

        [Display(Name = "State")]
        public string StateJSON { get; set; }

    }
}
