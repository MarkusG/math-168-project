using System.Globalization;
using CsvHelper;
using StopTimeCleaner;

using var reader = new StreamReader("/home/mark/school/math168/project/Boston_MBTA_Data/stop_times.txt");
using var csvr = new CsvReader(reader, CultureInfo.InvariantCulture);

using var output = File.OpenWrite("/home/mark/school/math168/project/delay_data/stop_times_clean.csv");
using var writer = new StreamWriter(output);
using var csvw = new CsvWriter(writer, CultureInfo.InvariantCulture);
csvw.WriteHeader<CleanStopTime>();
csvw.NextRecord();

csvr.Read();
csvr.ReadHeader();
while (csvr.Read())
{
    var stopTime = csvr.GetRecord<StopTime>()!;

    var arrivalComponents = stopTime.ArrivalTime!.Split(":");
    var arrivalHours = int.Parse(arrivalComponents[0]);
    var arrivalMinutes = int.Parse(arrivalComponents[1]);
    var arrivalSeconds = int.Parse(arrivalComponents[2]);
    var arrivalSecondsSinceMidnight = 3600 * arrivalHours + 60 * arrivalMinutes + arrivalSeconds;

    var departureComponents = stopTime.DepartureTime!.Split(":");
    var departureHours = int.Parse(departureComponents[0]);
    var departureMinutes = int.Parse(departureComponents[1]);
    var departureSeconds = int.Parse(departureComponents[2]);
    var departureSecondsSinceMidnight = 3600 * departureHours + 60 * departureMinutes + departureSeconds;

    csvw.WriteRecord(new CleanStopTime
    {
        TripId = stopTime.TripId,
        StopId = stopTime.StopId,
        ArrivalTime = arrivalSecondsSinceMidnight,
        DepartureTime = departureSecondsSinceMidnight
    });
    csvw.NextRecord();
}