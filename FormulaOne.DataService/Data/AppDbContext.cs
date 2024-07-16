using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.DataService.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    // define the DbSet for the entities
    public virtual DbSet<Driver> Drivers { get; set; }
    public virtual DbSet<Achievement> Achievements { get; set; }

    // define the relationship between the entities
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>()
            .HasOne(a => a.Driver)
            .WithMany(d => d.Achievements)
            .HasForeignKey(a => a.DriverId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Achievement_Driver");
    }
}
