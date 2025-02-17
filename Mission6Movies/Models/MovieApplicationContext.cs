using Microsoft.EntityFrameworkCore;

namespace Mission6Movies.Models
{
    
    // Bridge between application and database
    public class MovieApplicationContext : DbContext
    {
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base(options)
        {
            
        }
        
        public DbSet<MovieApplication> MovieApplications { get; set; }
    }
}