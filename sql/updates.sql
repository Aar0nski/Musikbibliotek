PRAGMA foreign_keys = ON;

-- 1) Uppdatera land på en artist
UPDATE Artist
SET Country = 'United Kingdom'
WHERE Name = 'Adele';

-- 2) Ökar låtlängden med 10 sekunder för alla låtar i albumet "Discovery"
UPDATE Track
SET DurationSeconds = DurationSeconds + 10
WHERE AlbumId = (SELECT Id FROM Album WHERE Title = 'Discovery');