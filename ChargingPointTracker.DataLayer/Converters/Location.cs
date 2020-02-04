using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common = ChargingPointTracker.Common;

namespace ChargingPointTracker.DataLayer
{
    public partial class Location
    {
        public static implicit operator Location(Common.Location location)
        {
            return new Location()
            {
                LocationId = location.LocationId,
                Address = location.Address,
                City = location.City,
                PostalCode = location.PostalCode,
                Country = location.Country,
                LastUpdated = location.LastUpdated,
                Name = location.Name,
                Type = location.Type
            };
        }

        public static implicit operator Common.Location(Location location)
        {
            return new Common.Location() 
            {
                LocationId = location.LocationId,
                Address = location.Address,
                City = location.City,
                PostalCode = location.PostalCode,
                Country = location.Country,
                LastUpdated = location.LastUpdated,
                Name = location.Name,
                Type = location.Type,
                ChargePoints = location.ChargePoints.Select(c => (Common.ChargePoint)c).ToList()
            };
        }
    }
}
