select distinct T1.Transport_name
from Transports as T1 inner join Stages as S1 inner join Tours as To1
on To1.Tour_id = S1.Tour_id
on S1.Transport_id = T1.Transport_id
group by T1.Transport_name
having count(distinct S1.Stage_id) > 
(select count(distinct S2.Stage_id)
from Stages as S2 inner join Tours as To2
on To2.Tour_id = S2.Tour_id
where To2.Tour_name = TourName
)