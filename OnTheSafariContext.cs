using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ORM_S
{
  public partial class OnTheSafariContext : DbContext
  {
    public OnTheSafariContext()
    {
    }

    public OnTheSafariContext(DbContextOptions<OnTheSafariContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseNpgsql("server=localhost;database=OnTheSafari");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");
    }

    public DbSet<Animal> Animals { get; set; }
  }
}
