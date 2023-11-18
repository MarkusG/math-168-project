using System.Globalization;
using CsvHelper;
using StopTimeCleaner;

using var reader = new StreamReader("/home/mark/school/math168/project/Boston_MBTA_Data/stop_times.txt");
using var csvr = new CsvReader(reader, CultureInfo.InvariantCulture);

using var output = File.OpenWrite("/home/mark/school/math168/project/delay_data/stop_times_clean.csv");
using var writer = new StreamWriter(output);
using var csvw = new CsvWriter(writer, CultureInfo.InvariantCulture);
csvw.WriteHeader<CleanStopTime>();

csvr.Read();
csvr.ReadHeader();
while (csvr.Read())
{
    var stopTime = csvr.GetRecord<StopTime>()!;
    var arrivalComponents = stopTime.ArrivalTime!.Split(":");
    var hours = int.Parse(arrivalComponents[0]);
    var minutes = int.Parse(arrivalComponents[1]);
    var seconds = int.Parse(arrivalComponents[2]);
    var secondsSinceMidnight = 3600 * hours + 60 * minutes + seconds;
    
    csvw.WriteRecord(new CleanStopTime
    {
        TripId = stopTime.TripId,
        StopId = stopTime.StopId,
        ArrivalTime = secondsSinceMidnight
    });
    csvw.NextRecord();
}