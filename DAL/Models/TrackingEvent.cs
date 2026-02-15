namespace fleettrackapi.dal.models
{
    public sealed class TrackingEvent
    {
        public Guid TripId { get; set; }
        public DateTime TimestampUtc { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public float Accuracy { get; set; }

        public string TripState { get; set; } = default!;
        public string SimHash { get; set; } = default!;
    }

}