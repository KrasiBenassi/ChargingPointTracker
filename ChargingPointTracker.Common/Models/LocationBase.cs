using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ChargingPointTracker.Common
{
    public class LocationBase
    {
        [Required]
        [StringLength(39)]
        public string LocationId { get; set; }

        [Required]
        [StringLength(45)]
        public string Type { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(45)]
        public string Address { get; set; }

        [Required]
        [StringLength(45)]
        public string City { get; set; }

        [Required]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(45)]
        public string Country { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }
    }
}