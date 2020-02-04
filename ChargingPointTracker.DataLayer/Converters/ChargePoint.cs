using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common = ChargingPointTracker.Common;

namespace ChargingPointTracker.DataLayer
{
    public partial class ChargePoint
    {
        public static implicit operator ChargePoint(Common.ChargePoint chargePoint)
        {
            return new ChargePoint()
            {
                ChargePointId = chargePoint.ChargePointId,
                FloorLevel = chargePoint.FloorLevel,
                LastUpdated = chargePoint.LastUpdated,
                Status = chargePoint.Status
            };
        }

        public static implicit operator Common.ChargePoint(ChargePoint chargePoint)
        {
            return new Common.ChargePoint()
            {
                ChargePointId = chargePoint.ChargePointId,
                FloorLevel = chargePoint.FloorLevel,
                LastUpdated = chargePoint.LastUpdated,
                Status = chargePoint.Status
            };
        }
    }
}
