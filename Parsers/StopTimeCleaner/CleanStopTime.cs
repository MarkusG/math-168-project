using CsvHelper.Configuration.Attributes;

namespace StopTimeCleaner;

public class CleanStopTime
{
    [Name("trip_id")]
    public string? TripId { get; set; }
    
    [Name("stop_id")]
    public string? StopId { get; set; }
    
    [Name("arrival_time")]
    public int ArrivalTime { get; set; }
}