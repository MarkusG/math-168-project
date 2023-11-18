using CsvHelper.Configuration.Attributes;

namespace StopTimeCleaner;

public class StopTime
{
    [Name("trip_id")]
    public string? TripId { get; set; }
    
    [Name("stop_id")]
    public string? StopId { get; set; }
    
    [Name("arrival_time")]
    public string? ArrivalTime { get; set; }
    
    [Name("departure_time")]
    public string? DepartureTime { get; set; }
}