First modify lines_from_gtfs_static.sql and supply the appropriate line color.
Then run it and pipe the output to a file. Then manually edit the file to
separate each trip, and then run clean_sql_output.sh on each file to clean it
to just the stop names. Then it will be in a format that can be passed to the
script in Willie's notebook.
