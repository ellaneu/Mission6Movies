using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6Movies.Models;


// Creates a model for the form so the Model First Method can be performed
public class MovieApplication
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    
    [ForeignKey("CategoryId")]
    public int? CategoryId {get; set;}
    public Category? Category {get; set;}
    
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Year is required")]
    // Makes it so the user is not allowed to enter a year lower than 1888
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be greater than 1888")]
    public string Year { get; set; }
    public string? Director { get; set; }
    public string? Rating { get; set; }
    
    [Required(ErrorMessage = "Edited (yes/no) is required")]
    public bool Edited { get; set; }
    public string? LentTo { get; set; }
    
    [Required(ErrorMessage = "Copied to Plex is required")]
    public bool CopiedToPlex { get; set; }
    public string? Notes { get; set; }
    
}