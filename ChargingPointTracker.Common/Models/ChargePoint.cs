using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ChargingPointTracker.Common
{
    public class ChargePoint
    {
        [Required]
        [StringLength(39)]
        public string ChargePointId { get; set; }

        [Required]
        [StringLength(39)]
        public string Status { get; set; }

        [StringLength(4)]
        public string FloorLevel { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }
    }
}