SELECT T1.Tour_name
FROM Tours AS T1
WHERE (
SELECT COUNT(DISTINCT CO1.Country_Id)
FROM Countries AS CO1 INNER JOIN Cities AS CI1 INNER JOIN Hotels AS H1 INNER JOIN Stages AS S1
ON S1.Hotel_id = H1.Hotel_id
ON CI1.City_id = H1.City_id
ON CO1.Country_Id = CI1.Country_id
WHERE T1.Tour_id = S1.Tour_id
) =
(SELECT COUNT(DISTINCT CO2.Country_Name)
FROM Countries AS CO2)