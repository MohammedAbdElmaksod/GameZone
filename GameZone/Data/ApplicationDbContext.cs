using GameZone.Models;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Game> TbGames { get; set; }
        public virtual DbSet<Device> TbDevices { get; set; }
        public virtual DbSet<Category> TbCategory { get; set; }
        public virtual DbSet<GameDevice> TbGameDevices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GameDevice>().HasKey(k => new { k.GameId, k.DeviceId });
            modelBuilder.Entity<Device>().HasData(new Device[]
            {
                new Device{Id=1,Name="Playstation",Icon="bi bi-playstation"},
                new Device{Id=2,Name="Xbox",Icon="bi bi-xbox"},
                new Device{Id=3,Name="PC",Icon="bi bi-pc-display"},
            });
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category{Id=1,Name="Sport"},
                new Category{Id=2,Name="Action"},
                new Category{Id=3,Name="Film"},
                new Category{Id=4,Name="Story"},
            });
        }
    }
}
