namespace ConsoleApp1;

public class RootObject
{
    public Entity[] entity { get; set; }
    public Header header { get; set; }
}

public class Entity
{
    public string id { get; set; }
    public Trip_update trip_update { get; set; }
}

public class Trip_update
{
    public Stop_time_update[]? stop_time_update { get; set; }
    public int timestamp { get; set; }
    public Trip trip { get; set; }
    public Vehicle vehicle { get; set; }
}

public class Stop_time_update
{
    public Departure? departure { get; set; }
    public string stop_id { get; set; }
    public int stop_sequence { get; set; }
    public Arrival? arrival { get; set; }
    public string schedule_relationship { get; set; }
}

public class Departure
{
    public int time { get; set; }
    public int uncertainty { get; set; }
}

public class Arrival
{
    public int time { get; set; }
    public int uncertainty { get; set; }
}

public class Trip
{
    public int direction_id { get; set; }
    public string route_id { get; set; }
    public string start_date { get; set; }
    public string start_time { get; set; }
    public string trip_id { get; set; }
    public string schedule_relationship { get; set; }
}

public class Vehicle
{
    public string id { get; set; }
    public string label { get; set; }
}

public class Header
{
    public string gtfs_realtime_version { get; set; }
    public string incrementality { get; set; }
    public int timestamp { get; set; }
}