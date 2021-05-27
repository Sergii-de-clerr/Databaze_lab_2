select distinct To1.Tourist_name
from Tourists as To1 INNER JOIN Vouchers as V1 INNER JOIN Tours as T1
on V1.Tour_id = T1.Tour_id
on To1.Tourist_id = V1.Tourist_id
where T1.Tour_id in 
(select T2.Tour_id
from Tours as T2 INNER JOIN Vouchers as V2 INNER JOIN Tourists as To2
on To2.Tourist_id = V2.Tourist_id
on V2.Tour_id = T2.Tour_id
where To2.Tourist_name = TouristName)
and To1.Tourist_name != TouristName