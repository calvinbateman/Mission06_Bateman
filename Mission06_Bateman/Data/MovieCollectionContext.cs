using Microsoft.EntityFrameworkCore;
using Mission06_Bateman.Models;


namespace Mission06_Bateman.Data;
public class MovieCollectionContext : DbContext
{
    public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options)
        : base(options)
    {
    }
    
    public DbSet<Movie> Movies { get; set; }
}   