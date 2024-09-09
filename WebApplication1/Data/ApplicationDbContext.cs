using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
         
        }
        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry { 
                    Id = 1, 
                    Title = "Work", 
                    Content = "Work Today Tomorrow and always..", 
                    Created = DateTime.Now
                },
                new DiaryEntry
                {
                    Id = 2,
                    Title = "Travel",
                    Content = "Travel Today Tomorrow and always..",
                    Created = DateTime.Now
                },
                new DiaryEntry
                {
                    Id = 3,
                    Title = "Explore",
                    Content = "Explore Today Tomorrow and always..",
                    Created = DateTime.Now
                }
                );
        }
    }
}
