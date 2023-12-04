.mode csv
.headers on
.import delays.csv delays
.import ../GTFS_Static/stop_times.txt stop_times
.import ../GTFS_Static/trips.txt trips
.import ../GTFS_Static/routes.txt routes
.import ../GTFS_Static/stops.txt stops

select distinct s.stop_name,delays.avg_delay from delays
inner join stop_times st on st.stop_id = delays.stop_id
inner join trips t on t.trip_id = st.trip_id
inner join routes r on r.route_id = t.route_id
inner join stops s on s.stop_id = delays.stop_id
where r.network_id = 'rapid_transit';
