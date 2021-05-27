select distinct To1.Tour_name
from Tours as To1 INNER JOIN
(Tourists as T1 INNER JOIN Vouchers as V1
ON T1.Tourist_id = V1.Tourist_id
)
ON To1.Tour_id = V1.Tour_id
where T1.Tourist_name = TouristName
