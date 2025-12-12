using System;
using System.Collections.Generic;
using System.Text;

namespace Musikbibliotek.Models;

public class Track
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int DurationSeconds { get; set; }

    public int AlbumId { get; set; }
    public Album Album { get; set; } = null!;
}