using Microsoft.EntityFrameworkCore;

namespace ETLProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Trip> Trips { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TripsDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Trip>()
                .HasIndex(t => t.PickupDateTime);

            modelBuilder.Entity<Trip>()
                .HasIndex(t => t.DropoffDateTime);

            modelBuilder.Entity<Trip>()
                .HasIndex(t => t.TripDistance);

            modelBuilder.Entity<Trip>()
                .HasIndex(t => t.PULocationID);

            modelBuilder.Entity<Trip>()
                .HasIndex(t => t.DOLocationID);
        }

    }
}
