using System.ComponentModel.DataAnnotations;

namespace Mission06_Bateman.Models;

public class Movie
{
    public int MovieId { get; set; }

    /// <summary>Maps to DB; not shown on form. Controller sets default for new records.</summary>
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Year is required.")]
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set; }

    public string? Director { get; set; }

    /// <summary>DB stores TEXT (e.g. PG-13, TV-14, NR, UR).</summary>
    public string? Rating { get; set; }

    [Required(ErrorMessage = "Please choose Yes or No for Edited.")]
    public bool? Edited { get; set; }

    public string? LentTo { get; set; }

    [Required(ErrorMessage = "Please choose Yes or No for Copied to Plex.")]
    public bool? CopiedToPlex { get; set; }

    [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string? Notes { get; set; }
}
