using System.ComponentModel.DataAnnotations;

namespace Mission06_Bateman.Models;

public enum Rating
{
    G,
    PG,
    PG13,
    R
}


public class Movie
{
    public int MovieId { get; set; }  // Primary key 

    [Required]
    public string Category { get; set; } = string.Empty; // the .Empty means that if no string data is entered it defaults to empy string "" instead of null

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    [Range(1888, 2100)]
    public int Year { get; set; }

    [Required]
    public string Director { get; set; } = string.Empty;

    [Required]
    public Rating Rating { get; set; }

    // Not required
    public bool? Edited { get; set; }

    // Not required
    public string? LentTo { get; set; }

    // Not required, max 25 chars
    [StringLength(25)]
    public string? Notes { get; set; }
}
