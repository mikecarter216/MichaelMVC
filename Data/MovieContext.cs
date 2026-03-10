using Microsoft.EntityFrameworkCore;
using MyMoviesApp.Models;

namespace MyMoviesApp.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
