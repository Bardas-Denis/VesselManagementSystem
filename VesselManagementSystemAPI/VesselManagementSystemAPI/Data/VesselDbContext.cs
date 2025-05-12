using Microsoft.EntityFrameworkCore;
using VesselManagementSystemAPI.Models;

namespace VesselManagementSystemAPI.Data
{
    public class VesselDbContext: DbContext
    {
        public VesselDbContext(DbContextOptions<VesselDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ship> Ships { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShipOwner> ShipOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ship>().ToTable("Ship");
            modelBuilder.Entity<Owner>().ToTable("Owner");
            modelBuilder.Entity<Category>().ToTable("Ship_Category");
            modelBuilder.Entity<ShipOwner>().ToTable("Owner_Ship");

            // Ship && Owner relation
            modelBuilder.Entity<ShipOwner>()
                .HasKey(so => new { so.ShipId, so.OwnerId });

            modelBuilder.Entity<ShipOwner>()
                .HasOne(so => so.Ship)
                .WithMany(s => s.ShipOwners)
                .HasForeignKey(so => so.ShipId);

            modelBuilder.Entity<ShipOwner>()
                .HasOne(so => so.Owner)
                .WithMany(o => o.ShipOwners)
                .HasForeignKey(so => so.OwnerId);

            // Ship && Category relation
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Category>()
                .HasOne(c => c.Ship)
                .WithOne(s => s.Category)
                .HasForeignKey<Category>(c => c.ShipId);

            base.OnModelCreating(modelBuilder);
        }
    }

}
