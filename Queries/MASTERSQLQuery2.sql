SELECT C1.Country_Name
FROM Countries AS C1
WHERE (
SELECT AVG(DISTINCT T1.Duration_in_days)
FROM Tours AS T1 INNER JOIN Stages AS S1 INNER JOIN Hotels AS H1 INNER JOIN Cities AS CI1
ON CI1.City_id = H1.City_id
ON S1.Hotel_id = H1.Hotel_id
ON S1.Tour_id = T1.Tour_id
WHERE CI1.Country_id = C1.Country_Id
) >= Seredne