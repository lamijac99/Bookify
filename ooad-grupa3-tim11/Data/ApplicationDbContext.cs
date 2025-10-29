using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ooad_grupa3_tim11.Models;

namespace ooad_grupa3_tim11.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

   
        public DbSet<Location> Location { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RegisteredUser> RegisteredUser { get; set; }
        public DbSet<Reservation> Reservation { get; set; }

        public DbSet<Review> Review { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<Location>().ToTable("Location");
            modelBuilder.Entity<Hotel>().ToTable("Hotel");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<RegisteredUser>().ToTable("RegisteredUser");

            modelBuilder.Entity<Reservation>().ToTable("Reservation");
            modelBuilder.Entity<Review>().ToTable("Review");


            base.OnModelCreating(modelBuilder);
        }
    }
}
