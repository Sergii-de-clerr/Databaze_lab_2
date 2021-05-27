SELECT Ts1.Tourist_name
 FROM Tourists AS Ts1
 WHERE 
 (EXISTS(
	(SELECT S1.Hotel_id
     FROM Stages AS S1 INNER JOIN Tours AS T1 INNER JOIN Vouchers AS V1
	 ON T1.Tour_id = V1.Tour_id
	 ON S1.Tour_id = T1.Tour_id
	 WHERE Ts1.Tourist_id = V1.Tourist_id
   	 )
	 EXCEPT(
    SELECT H2.Hotel_id
    FROM Hotels AS H2 INNER JOIN Stages AS S2 INNER JOIN Tours AS T2 INNER JOIN Vouchers AS V2 INNER JOIN Tourists AS Ts2
	ON Ts2.Tourist_id = V2.Tourist_id
	ON T2.Tour_id = V2.Tour_id
	ON T2.Tour_id = S2.Tour_id
	ON H2.Hotel_id = S2.Hotel_id
    WHERE Ts2.Tourist_name = TouristName
    )
))
AND
(
NOT EXISTS(
	(
    SELECT H2.Hotel_id
    FROM Hotels AS H2 INNER JOIN Stages AS S2 INNER JOIN Tours AS T2 INNER JOIN Vouchers AS V2 INNER JOIN Tourists AS Ts2
	ON Ts2.Tourist_id = V2.Tourist_id
	ON T2.Tour_id = V2.Tour_id
	ON T2.Tour_id = S2.Tour_id
	ON H2.Hotel_id = S2.Hotel_id
    WHERE Ts2.Tourist_name = TouristName
    )EXCEPT(
	SELECT S1.Hotel_id
     FROM Stages AS S1 INNER JOIN Tours AS T1 INNER JOIN Vouchers AS V1
	 ON T1.Tour_id = V1.Tour_id
	 ON S1.Tour_id = T1.Tour_id
	 WHERE Ts1.Tourist_id = V1.Tourist_id
   	 )
));