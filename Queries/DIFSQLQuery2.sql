select distinct C1.Country_Name
from Countries as C1 inner join Cities as Ci1 inner join Hotels as H1
on H1.City_id = Ci1.City_id
on Ci1.Country_id = C1.Country_Id
group by C1.Country_Name
having count(distinct H1.Hotel_id) < 
(select count(distinct H2.Hotel_id)
from Hotels as H2 inner join Cities as Ci2 inner join Countries as C2
on Ci2.Country_id = C2.Country_Id
on H2.City_id = Ci2.City_id
where C2.Country_Name = CountryName
)