using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChargingPointTracker.Common;
using Data = ChargingPointTracker.DataLayer;

namespace ChargingPointTracker.Controllers
{
    public class LocationsController : ApiController
    {
        private readonly Data.IChargingPointRepository m_ChargingPointRepository;

        public LocationsController(Data.IChargingPointRepository chargingPointRepository)
        {
            m_ChargingPointRepository = chargingPointRepository;
        }

        // GET: api/Locations/5
        public Location Get(string id)
        {
            return m_ChargingPointRepository.GetLocation(id);
        }

        // POST: api/Locations
        public IHttpActionResult Post([FromBody]LocationRequest locationRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var location = new Location()
            {
                LocationId = locationRequest.LocationId,
                Type = locationRequest.Type,
                Name = locationRequest.Name,
                Address = locationRequest.Address,
                City = locationRequest.City,
                PostalCode = locationRequest.PostalCode,
                Country = locationRequest.Country,
                LastUpdated = locationRequest.LastUpdated
            };

            try
            {
                m_ChargingPointRepository.AddLocation(location);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                throw;
            }

            return Ok();
        }

        public IHttpActionResult Put(string id, [FromBody]ChargePointRequest chargePointRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                m_ChargingPointRepository.UpsertChargepoint(id, chargePointRequest.ChargePoints);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                throw;
            }
            
            return Ok();
        }

        public IHttpActionResult Patch(string id, [FromBody] PatchLocationRequest patchLocationRequest)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var location = new Location()
            {
                LocationId = patchLocationRequest.LocationId,
                Type = patchLocationRequest.Type,
                Name = patchLocationRequest.Name,
                Address = patchLocationRequest.Address,
                City = patchLocationRequest.City,
                PostalCode = patchLocationRequest.PostalCode,
                Country = patchLocationRequest.Country,
                LastUpdated = patchLocationRequest.LastUpdated
            };

            m_ChargingPointRepository.UpdateLocation(id, location);

            return Ok();
        }
    }
}
