namespace fleettrackapi.dtos
{
    public record TrackingEventDto
    {
        public string TripId { get; init; } = default!;
        public DateTime TimestampUtc { get; init; }

        public double Latitude { get; init; }
        public double Longitude { get; init; }
        public float Accuracy { get; init; }

        public string TripState { get; init; } = default!;
        public string SimHash { get; init; } = default!;

        public string DeviceId { get; init; } = default!;
    }
}