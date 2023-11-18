.mode csv
.headers on
.import stop_times_clean.csv stop_times
.import stop_time_updates.csv updates

select st.stop_id, avg(u.arrival - st.arrival_time) as avg_delay
from stop_times st
inner join updates u on u.trip_id = st.trip_id and u.stop_id = st.stop_id
group by st.stop_id;
