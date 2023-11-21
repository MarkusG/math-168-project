select s.stop_name,delays.avg_delay from delays
inner join stop_times st on st.stop_id = delays.stop_id
inner join trips t on t.trip_id = st.trip_id
inner join routes r on r.route_id = t.route_id
inner join stops s on s.stop_id = delays.stop_id
where r.network_id = 'rapid_transit';
