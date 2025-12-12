using System;
using System.Collections.Generic;
using System.Text;

namespace Musikbibliotek.Models;

    public class Artist
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Country { get; set; }

    public List<Album> Albums { get; set; } = new();
}