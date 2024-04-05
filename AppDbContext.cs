using Microsoft.EntityFrameworkCore;
using Minimal.Models;

namespace Minimal
{
    class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<Workout> Workouts => Set<Workout>();
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Workout>().HasMany(e => e.Exercises);
        //}
    }
}
