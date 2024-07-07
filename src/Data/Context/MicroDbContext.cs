
using Microsoft.EntityFrameworkCore;

namespace MyMicroservice.Data;

public class MicroDbContext : DbContext
{
    public MicroDbContext(DbContextOptions<MicroDbContext> options) : base(options)
    {        
    }

    public virtual DbSet<Persons> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persons>(entity => 
        {
            base.OnModelCreating(modelBuilder);

            entity.HasKey(e => e.Id);

            entity.Property(e => e.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("varchar")
                .HasMaxLength(1000);

            entity.Property(e => e.LastName)
                .HasColumnName("LastName")
                .HasColumnType("varchar")
                .HasMaxLength(1000);

            entity.Property(e => e.Birthday)
                .HasColumnName("Birthday")
                .HasColumnType("DateTime");
        });
    }
}