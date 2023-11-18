using System.Globalization;
using System.Text.Json;
using ConsoleApp1;
using CsvHelper;

var data = File.ReadAllText("/home/mark/school/math168/project/delay_data/trip_updates.json");
var updates = JsonSerializer.Deserialize<RootObject>(data);

var output = new List<OutputRecord>();

foreach (var e in updates!.entity.Where(e => e.trip_update.stop_time_update is not null))
{
    foreach (var u in e.trip_update.stop_time_update!)
    {
        var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        // the timestamps are 19 hours off for some reason
        epoch = epoch.AddHours(19);
        DateTime? arrivalTimestamp = u.arrival is null ? null : epoch.AddSeconds(u.arrival.time);
        DateTime? departureTimestamp = u.departure is null ? null : epoch.AddSeconds(u.departure.time);
        int? arrivalSeconds = arrivalTimestamp is null ? null : (int)Math.Floor(arrivalTimestamp!.Value.TimeOfDay.TotalSeconds);
        int? departureSeconds = departureTimestamp is null ? null : (int)Math.Floor(departureTimestamp!.Value.TimeOfDay.TotalSeconds);
        var update = new OutputRecord(
            e.trip_update.trip.trip_id,
            u.stop_id,
            arrivalSeconds,
            departureSeconds);
        output.Add(update);
    }
}

using var sw = new StreamWriter("/home/mark/school/math168/project/delay_data/stop_time_updates.csv");
using var csvw = new CsvWriter(sw, CultureInfo.InvariantCulture);
csvw.WriteRecords(output);