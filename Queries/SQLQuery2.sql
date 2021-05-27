select distinct Ho1.Hotel_name
from Hotels as Ho1 INNER JOIN
(Countries as C1 INNER JOIN Cities as Ci1
ON C1.Country_Id = Ci1.Country_id
)
ON Ho1.City_id = Ci1.City_id
where C1.Country_Name = CountryName
