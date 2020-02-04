using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ChargingPointTracker.Common
{
    public class ChargePointRequest
    {
        [Required]
        [StringLength(39)]
        public string LocationId { get; set; }

        public List<ChargePoint> ChargePoints { get; set; }
    }
}