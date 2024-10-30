using BlazorRecipeServer.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorRecipeServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
