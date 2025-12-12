-- 1) Visa låtar med albumtitel och artistnamn (Track -> Album -> Artist)
SELECT
    t.Title AS TrackTitle,
    a.Title AS AlbumTitle,
    ar.Name AS ArtistName,
    t.DurationSeconds
FROM Track t
JOIN Album a ON t.AlbumId = a.Id
JOIN Artist ar ON a.ArtistId = ar.Id
ORDER BY ArtistName, AlbumTitle;

-- 2) Visa antal låtar per artist (JOIN + GROUP BY)
SELECT
    ar.Name AS ArtistName,
    COUNT(t.Id) AS TrackCount
FROM Artist ar
JOIN Album a ON a.ArtistId = ar.Id
JOIN Track t ON t.AlbumId = a.Id
GROUP BY ar.Name
ORDER BY TrackCount DESC;