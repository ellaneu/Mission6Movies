using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6Movies.Models;


// Creates a model for the form so the Model First Method can be performed
public class MovieApplication
{
    [Key]
    [Required]
    public int MovieID { get; set; }
    
    [Required]
    [ForeignKey("CategoryId")]
    public int CategoryId {get; set;}
    public Categories Category {get; set;}
    
    [Required]
    public string Title { get; set; }
    [Required]
    public string Year { get; set; }
    [Required]
    public string Director { get; set; }
    [Required]
    public string Rating { get; set; }
    public bool? Edited { get; set; }
    public string? LentTo { get; set; }
    
    public string CopiedToPlex { get; set; }
    public string? Notes { get; set; }
    
}