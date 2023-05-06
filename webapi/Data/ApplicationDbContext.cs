using Microsoft.EntityFrameworkCore;
using webapi.Entities;

namespace webapi.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<BulletPoint> BulletPoints { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
