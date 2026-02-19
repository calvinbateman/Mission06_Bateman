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
    public int CategoryId { get; set; }

    [Required]
    public string? Title { get; set; } = string.Empty;

    [Required]
    [CurrentYear] // This has been abstracted so that it can check against the current year. Look in /Models/CuurentYearAttribute.cs to find logic
    public int Year { get; set; }

    [Required]
    public string? Director { get; set; } = string.Empty;

    [Required]
    public Rating Rating { get; set; }

    [Required]
    public bool? Edited { get; set; }

    // Not required
    public string? LentTo { get; set; }
    
    [Required]
    public bool? CopiedToPlex { get; set; }

    // Not required, max 25 chars
    [StringLength(25)]
    public string? Notes { get; set; }
}
