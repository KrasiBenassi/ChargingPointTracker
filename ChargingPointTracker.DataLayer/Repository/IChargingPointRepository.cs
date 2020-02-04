using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common = ChargingPointTracker.Common;

namespace ChargingPointTracker.DataLayer
{
    public interface IChargingPointRepository
    {
        void AddLocation(Common.Location location);

        Common.Location GetLocation(string locationId);

        void UpsertChargepoint(string locationId, List<Common.ChargePoint> chargePoints);

        void UpdateLocation(string locationId, Location location);
    }
}
