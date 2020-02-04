using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common = ChargingPointTracker.Common;

namespace ChargingPointTracker.DataLayer
{
    public class ChargingPointRepository : IChargingPointRepository
    {
        public void AddLocation(Common.Location location)
        {
            using (var context = new ChargingPointTrackerEntities())
            {
                if (context.Locations.Any(l => l.LocationId == location.LocationId))
                {
                    throw new ArgumentException($"Location with location id {location.LocationId} already exist.");
                }

                context.Locations.Add(location);
                context.SaveChanges();
            }
        }

        public Common.Location GetLocation(string locationId)
        {
            using (var context = new ChargingPointTrackerEntities())
            {
                var location = context.Locations.FirstOrDefault(l => l.LocationId == locationId);
                return location;
            }
        }

        public void UpdateLocation(string locationId, Location location)
        {
            using (var context = new ChargingPointTrackerEntities())
            {
                var locationData = context.Locations.FirstOrDefault(l => l.LocationId == locationId);

                if (locationData != null)
                {
                    locationData.Type = location.Type ?? locationData.Type;
                    locationData.Name = location.Name ?? locationData.Name;
                    locationData.Address = location.Address ?? locationData.Address;
                    locationData.City = location.City ?? locationData.City;
                    locationData.PostalCode = location.PostalCode ?? locationData.PostalCode;
                    locationData.Country = location.Country ?? locationData.Country;
                    locationData.LastUpdated = DateTime.Now;
                }

                context.SaveChanges();
            }
        }

        public void UpsertChargepoint(string locationId, List<Common.ChargePoint> chargePoints)
        {
            using (var context = new ChargingPointTrackerEntities())
            {
                var location = context.Locations.FirstOrDefault(l => l.LocationId == locationId);

                if (location == null)
                {
                    throw new ArgumentException($"There is no location with LocationId {locationId}");
                }

                var locationChargePoints = context.ChargePoints.Where(c => c.LocationId == location.Id);
                var requestChargePointIds = chargePoints.Select(c => c.ChargePointId);


                foreach (var chargePoint in chargePoints)
                {
                    var dbChargePoint = locationChargePoints.FirstOrDefault(c => c.ChargePointId == chargePoint.ChargePointId);

                    if (dbChargePoint != null)
                    {
                        dbChargePoint.FloorLevel = chargePoint.FloorLevel;
                        dbChargePoint.LastUpdated = chargePoint.LastUpdated;
                        dbChargePoint.Status = chargePoint.Status;
                        dbChargePoint.LocationId = location.Id;
                    }
                    else
                    {
                        var chargePointModel = new ChargePoint()
                        {
                            ChargePointId = chargePoint.ChargePointId,
                            FloorLevel = chargePoint.FloorLevel,
                            LastUpdated = chargePoint.LastUpdated,
                            Status = chargePoint.Status,
                            LocationId = location.Id
                        };

                        context.ChargePoints.Add(chargePointModel);
                    }
                }

                foreach (var dbChargePoint in locationChargePoints)
                {
                    if (!requestChargePointIds.Contains(dbChargePoint.ChargePointId))
                    {
                        dbChargePoint.Status = "Removed";
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
