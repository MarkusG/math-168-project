.mode csv
.import ../GTFS_Static/stop_times.txt stop_times
.import ../GTFS_Static/trips.txt trips
.import ../GTFS_Static/stops.txt stops

select distinct st.trip_id, s.stop_name, st.stop_sequence from stop_times st
inner join stops s on s.stop_id = st.stop_id
where st.trip_id like 'canonical-Blue%'
order by st.trip_id, cast(st.stop_sequence as integer);
