using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChargingPointTracker.Common
{
    public class PatchLocationRequest
    {
        [Required]
        [StringLength(39)]
        public string LocationId { get; set; }

        [StringLength(45)]
        public string Type { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(45)]
        public string Address { get; set; }

        [StringLength(45)]
        public string City { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(45)]
        public string Country { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}