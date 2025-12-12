using System;
using System.Collections.Generic;
using System.Text;

namespace Musikbibliotek.Models;

public class Album
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int? ReleaseYear { get; set; }

    public int ArtistId { get; set; }
    public Artist Artist { get; set; } = null!;

    public List<Track> Tracks { get; set; } = new();
}

