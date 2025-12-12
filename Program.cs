using Musikbibliotek.Data;

namespace Musikbibliotek;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting...");

        using var db = new MusicContext();
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