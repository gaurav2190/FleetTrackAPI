namespace fleettrackapi.dal.models
{
    public sealed class Trip
    {
        public Guid TripId { get; set; }
        public string DeviceId { get; set; } = default!;
        public string SimHash { get; set; } = default!;
        public DateTime StartTimeUtc { get; set; }
        public DateTime? EndTimeUtc { get; set; }
        public string Status { get; set; } = default!;
    }

}