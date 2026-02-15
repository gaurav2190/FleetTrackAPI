namespace fleettrackapi.dal.repository
{
    using System.Data;
    using Dapper;
    using fleettrackapi.dal.models;

    public sealed class TrackingRepository : ITrackingRepository
    {
        private readonly IDbConnection _connection;

        public TrackingRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task InsertTripAsync(
            Trip trip,
            CancellationToken ct)
        {
            const string sql = """
                INSERT INTO Trips
                (TripId, DeviceId, SimHash, StartTimeUtc, Status)
                VALUES
                (@TripId, @DeviceId, @SimHash, @StartTimeUtc, @Status);
                """;

            await _connection.ExecuteAsync(
                new CommandDefinition(
                    sql,
                    trip,
                    cancellationToken: ct));
        }

        public async Task InsertTrackingEventsAsync(
            Guid tripId,
            IReadOnlyCollection<TrackingEvent> events,
            CancellationToken ct)
        {
            if (events.Count == 0)
                return;

            const string sql = """
                INSERT INTO tracking_events
                (trip_id, timestamp_utc, latitude, longitude, accuracy, trip_state, sim_hash)
                VALUES
                (@TripId, @TimestampUtc, @Latitude, @Longitude, @Accuracy, @TripState, @SimHash);
                """;

            // Dapper will execute this as a fast batch
            await _connection.ExecuteAsync(
                new CommandDefinition(
                    sql,
                    events,
                    cancellationToken: ct));
        }
    }
}