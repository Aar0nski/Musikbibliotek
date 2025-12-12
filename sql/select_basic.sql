-- 1) WHERE: alla album släppta efter 2010
SELECT Title, ReleaseYear
FROM Album
WHERE ReleaseYear > 2010
ORDER BY ReleaseYear;

-- 2) ORDER BY: alla låtar sorterade efter längd (längst först)
SELECT Title, DurationSeconds
FROM Track
ORDER BY DurationSeconds DESC;

-- 3) LIKE: artister vars namn börjar på 'D'
SELECT Name
FROM Artist
WHERE Name LIKE 'D%';

-- 4) WHERE + AND: låtar längre än 250 sekunder
SELECT Title, DurationSeconds
FROM Track
WHERE DurationSeconds > 250
ORDER BY DurationSeconds;

-- 5) GROUP BY: antal album per artist
SELECT ArtistId, COUNT(*) AS AlbumCount
FROM Album
GROUP BY ArtistId;

-- 6) GROUP BY: genomsnittlig låtlängd per album
SELECT AlbumId, AVG(DurationSeconds) AS AvgDuration
FROM Track
GROUP BY AlbumId;