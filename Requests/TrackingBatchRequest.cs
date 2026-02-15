namespace fleettrackapi.requests
{
    using fleettrackapi.dtos;
    
    public record TrackingBatchRequest
    {
        public string TripId { get; init; } = default!;
        public List<TrackingEventDto> Events { get; init; } = new();
    }
}