CREATE TABLE trips (
    trip_id UUID PRIMARY KEY,
    device_id TEXT NOT NULL,
    sim_hash TEXT NOT NULL,
    start_time_utc TIMESTAMP NOT NULL,
    end_time_utc TIMESTAMP NULL,
    status TEXT NOT NULL
);

CREATE TABLE tracking_events (
    id BIGSERIAL PRIMARY KEY,
    trip_id UUID NOT NULL,
    timestamp_utc TIMESTAMP NOT NULL,
    latitude DOUBLE PRECISION NOT NULL,
    longitude DOUBLE PRECISION NOT NULL,
    accuracy REAL NOT NULL,
    trip_state TEXT NOT NULL,
    sim_hash TEXT NOT NULL
);

CREATE INDEX ix_tracking_events_trip_time
ON tracking_events (trip_id, timestamp_utc);
