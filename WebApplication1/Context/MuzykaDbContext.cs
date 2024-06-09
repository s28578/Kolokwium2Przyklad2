using Microsoft.EntityFrameworkCore;
using WebApplication1.Configs;
using WebApplication1.Models;

namespace WebApplication1.Context;

public class MuzykaDbContext: DbContext
{
    public virtual DbSet<UtworAPBD> UtworyAPBD { get; set; }
    public virtual DbSet<MuzykAPBD> MuzycyAPBD { get; set; }
    public virtual DbSet<AlbumAPBD> AlbumyAPBD { get; set; }
    public virtual DbSet<WytworniaAPBD> WytwornieAPBD { get; set; }
    public virtual DbSet<WykonawcaUtworuAPBD> WykonawcaUtworuApbds { get; set; }

    public MuzykaDbContext()
    {
        
    }

    public MuzykaDbContext(DbContextOptions<MuzykaDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UtworAPBDConfig).Assembly);
    }
}