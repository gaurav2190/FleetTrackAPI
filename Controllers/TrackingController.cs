using fleettrackapi.dal.models;
using fleettrackapi.dal.repository;
using fleettrackapi.requests;
using Microsoft.AspNetCore.Mvc;

namespace fleettrackapi.controllers
{
    [ApiController]
    [Route("api/tracking")]
    public class TrackingController : ControllerBase
    {
        private readonly ITrackingRepository _trackingRepository;

        public TrackingController(ITrackingRepository trackingRepository)
        {
            this._trackingRepository = trackingRepository;
        }

        [HttpPost("events")]
        public async Task<IActionResult> IngestEvents(
            [FromBody] TrackingBatchRequest request,
            CancellationToken ct)
        {
            // 1. Validate
            if (request.Events.Count == 0)
                return BadRequest("No events");

            // 2. Persist (sync for now)
            var entities = request.Events.Select(e => new TrackingEvent
            {
                TripId = Guid.Parse(request.TripId),
                TimestampUtc = e.TimestampUtc.DateTime,
                Latitude = e.Latitude,
                Longitude = e.Longitude,
                Accuracy = e.Accuracy,
                TripState = e.TripState,
                SimHash = e.SimHash
            }).ToList();

            await this._trackingRepository.InsertTrackingEventsAsync(
                Guid.Parse(request.TripId),
                entities,
                ct);

            // 3. Respond fast
            return Ok(new { accepted = request.Events.Count });
        }
    }

}