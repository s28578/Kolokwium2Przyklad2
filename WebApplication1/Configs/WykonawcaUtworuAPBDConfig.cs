using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configs;

public class WykonawcaUtworuAPBDConfig: IEntityTypeConfiguration<WykonawcaUtworuAPBD>
{
    public void Configure(EntityTypeBuilder<WykonawcaUtworuAPBD> builder)
    {
        builder
            .HasKey(x => new{x.IdUtwor, x.IdMuzyk})
            .HasName("WykonawcaUtworuAPBD_pk");
        builder
            .HasOne(x => x.UtworAPBD)
            .WithMany(x => x.WykonawcaUtworow)
            .HasForeignKey(x => x.IdUtwor)
            .HasConstraintName("Utwor_WykAPBD")
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .HasOne(x => x.MuzykAPBD)
            .WithMany(x => x.WykonawcaUtworow)
            .HasForeignKey(x => x.IdMuzyk)
            .HasConstraintName("Muzyk_WykAPBD")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .ToTable("WykonawcaUtworuAPBD");
    }
}