using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ChargingPointTracker.Common
{
    public class Location : LocationBase
    {
        public List<ChargePoint> ChargePoints { get; set; }
    }
}