select distinct T1.Tour_name
from Tours as T1 INNER JOIN
(Stages as S1 INNER JOIN Hotels as H1
ON H1.Hotel_id = S1.Hotel_id
)
ON S1.Tour_id = T1.Tour_id
where H1.Hotel_name = HotelName