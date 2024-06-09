using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configs;

public class WytworniaAPBDConfig: IEntityTypeConfiguration<WytworniaAPBD>
{
    public void Configure(EntityTypeBuilder<WytworniaAPBD> builder)
    {
        builder
            .HasKey(bs => bs.IdWytwornia)
            .HasName("WytworniaAPBD_pk");
        
        builder
            .Property(x => x.Nazwa)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .ToTable("WytworniaAPBD");
    }
}