using HipDronesProject.Data.Models;
using HipDronesProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HipDronesProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserClaim<string>>().HasKey(p => new {p.Id});
        }

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Drone> Drones { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Video> Videos { get; set; }
       public DbSet<IdentityUser> Users { get; set; }
        
       
    }

    
}
