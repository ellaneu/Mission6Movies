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
    
    [Required]
    public string Title { get; set; }
    [Required]
    public string? Year { get; set; }
    public string? Director { get; set; }
    public string? Rating { get; set; }
    [Required]
    public bool Edited { get; set; }
    public string? LentTo { get; set; }
    [Required]
    public bool CopiedToPlex { get; set; }
    public string? Notes { get; set; }
    
}