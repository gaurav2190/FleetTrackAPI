using fleettrackapi.dal.models;

namespace fleettrackapi.dal.repository
{
    public interface ITrackingRepository
    {
        Task InsertTripAsync(Trip trip, CancellationToken ct);
        Task InsertTrackingEventsAsync(
            Guid tripId,
            IReadOnlyCollection<TrackingEvent> events,
            CancellationToken ct);
    }

}