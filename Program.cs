using Musikbibliotek.Data;
using Musikbibliotek.Models;
using Microsoft.EntityFrameworkCore;


namespace Musikbibliotek;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting...");

        using var db = new MusicContext();
        db.Database.Migrate();

        if (!db.Artists.Any())
        {
            db.Artists.AddRange(
                new Artist { Name = "Daft Punk", Country = "France" },
                new Artist { Name = "Adele", Country = "UK" },
                new Artist { Name = "Kent", Country = "Sweden" }
            );
            db.SaveChanges();

            var daftPunkId = db.Artists.Single(a => a.Name == "Daft Punk").Id;
            var adeleId = db.Artists.Single(a => a.Name == "Adele").Id;
            var kentId = db.Artists.Single(a => a.Name == "Kent").Id;

            db.Albums.AddRange(
                new Album { Title = "Discovery", ReleaseYear = 2001, ArtistId = daftPunkId },
                new Album { Title = "Random Access Memories", ReleaseYear = 2013, ArtistId = daftPunkId },
                new Album { Title = "21", ReleaseYear = 2011, ArtistId = adeleId },
                new Album { Title = "Vapen & Ammunition", ReleaseYear = 2002, ArtistId = kentId }
            );
            db.SaveChanges();

            var discoveryId = db.Albums.Single(a => a.Title == "Discovery").Id;
            var ramId = db.Albums.Single(a => a.Title == "Random Access Memories").Id;
            var a21Id = db.Albums.Single(a => a.Title == "21").Id;
            var vaaId = db.Albums.Single(a => a.Title == "Vapen & Ammunition").Id;

            db.Tracks.AddRange(
                new Track { Title = "One More Time", DurationSeconds = 320, AlbumId = discoveryId },
                new Track { Title = "Harder, Better, Faster, Stronger", DurationSeconds = 224, AlbumId = discoveryId },
                new Track { Title = "Get Lucky", DurationSeconds = 369, AlbumId = ramId },
                new Track { Title = "Instant Crush", DurationSeconds = 337, AlbumId = ramId },
                new Track { Title = "Rolling in the Deep", DurationSeconds = 228, AlbumId = a21Id },
                new Track { Title = "Someone Like You", DurationSeconds = 285, AlbumId = a21Id },
                new Track { Title = "Sverige", DurationSeconds = 214, AlbumId = vaaId },
                new Track { Title = "Dom andra", DurationSeconds = 250, AlbumId = vaaId }
            );
            db.SaveChanges();
        }
        Console.WriteLine("DbContext created OK.");

        // 1) Album efter 2010
        var albumsAfter2010 = db.Albums
            .Where(a => a.ReleaseYear > 2010)
            .OrderBy(a => a.ReleaseYear)
            .Select(a => new { a.Title, a.ReleaseYear })
            .ToList();

        // 2) Tracks sorterade på längd
        var tracksByLength = db.Tracks
            .OrderByDescending(t => t.DurationSeconds)
            .Select(t => new { t.Title, t.DurationSeconds })
            .ToList();

        // 3) JOIN: Track + Album + Artist
        var trackDetails = db.Tracks
            .Select(t => new
            {
                TrackTitle = t.Title,
                AlbumTitle = t.Album.Title,
                ArtistName = t.Album.Artist.Name,
                t.DurationSeconds
            })
            .OrderBy(x => x.ArtistName)
            .ThenBy(x => x.AlbumTitle)
            .ToList();

        Console.WriteLine($"Albums after 2010: {albumsAfter2010.Count}");
        Console.WriteLine($"Tracks total: {tracksByLength.Count}");
        Console.WriteLine($"Joined rows: {trackDetails.Count}");
    }
}