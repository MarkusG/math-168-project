.mode csv
.import ../Boston_MBTA_Data/stop_times.txt stop_times
.import ../Boston_MBTA_Data/trips.txt trips
.import ../Boston_MBTA_Data/stops.txt stops

select distinct st.trip_id, s.stop_name, st.stop_sequence from stop_times st
inner join stops s on s.stop_id = st.stop_id
where st.trip_id like 'canonical-Blue%'
order by st.trip_id, cast(st.stop_sequence as integer);
