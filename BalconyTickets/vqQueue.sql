ALTER VIEW dbo.vwQueue (user_name, balcony_name, general_pos, queue_pos, avg_time)
 AS
SELECT q.queue_id, u.user_name, b.balcony_name,
 row_number() OVER (ORDER BY q.queue_created) as general_pos,
 row_number() OVER (PARTITION BY q.balcony_id ORDER BY q.balcony_id, q.queue_created) as queue_pos ,
 row_number() OVER (PARTITION BY q.balcony_id  ORDER BY q.balcony_id, q.queue_created)*b.balcony_average as avg_time
 FROM queue q
INNER JOIN [user] u on q.user_id=u.user_id
INNER JOIN balcony b on q.balcony_id=b.balcony_id
WHERE q.queue_status='A';
