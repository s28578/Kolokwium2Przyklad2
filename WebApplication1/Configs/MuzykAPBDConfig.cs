using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configs;

public class MuzykAPBDConfig: IEntityTypeConfiguration<MuzykAPBD>
{
    public void Configure(EntityTypeBuilder<MuzykAPBD> builder)
    {
        builder
            .HasKey(bs => bs.IdMuzyk)
            .HasName("MuzykAPBD_pk");
        builder
            .Property(x => x.Imie)
            .IsRequired()
            .HasMaxLength(30);
        builder
            .Property(x => x.Nazwisko)
            .IsRequired()
            .HasMaxLength(40);
        builder
            .Property(x => x.Pseudonim)
            .HasMaxLength(50);
        
        builder
            .ToTable("MuzykAPBD");
    }
}