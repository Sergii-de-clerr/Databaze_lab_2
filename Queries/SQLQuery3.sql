select distinct T1.Tour_name
from Tours as T1 INNER JOIN
(Stages as S1 INNER JOIN Transports as To1
ON To1.Transport_id = S1.Transport_id
)
ON S1.Tour_id = T1.Tour_id
where To1.Transport_name = TransportName