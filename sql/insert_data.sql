PRAGMA foreign_keys = ON;

-- Artists
INSERT INTO Artist (Name, Country) VALUES
('Daft Punk', 'France'),
('Adele', 'UK'),
('Kent', 'Sweden');

-- Albums
INSERT INTO Album (Title, ReleaseYear, ArtistId) VALUES
('Discovery', 2001, 1),
('Random Access Memories', 2013, 1),
('21', 2011, 2),
('Vapen & Ammunition', 2002, 3);

-- Tracks
INSERT INTO Track (Title, DurationSeconds, AlbumId) VALUES
('One More Time', 320, 1),
('Harder, Better, Faster, Stronger', 224, 1),
('Get Lucky', 369, 2),
('Instant Crush', 337, 2),
('Rolling in the Deep', 228, 3),
('Someone Like You', 285, 3),
('Sverige', 214, 4),
('Dom andra', 250, 4);