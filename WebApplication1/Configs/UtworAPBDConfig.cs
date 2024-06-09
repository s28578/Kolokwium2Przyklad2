using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configs;

public class UtworAPBDConfig: IEntityTypeConfiguration<UtworAPBD>
{
    public void Configure(EntityTypeBuilder<UtworAPBD> builder)
    {
        builder
            .HasKey(bs => bs.IdUtwor)
            .HasName("UtworAPBD_pk");
        
        builder
            .Property(x => x.NazwaUtworu)
            .IsRequired()
            .HasMaxLength(30);
        builder
            .HasOne(x => x.AlbumAPBD)
            .WithMany(x => x.Utwory)
            .HasForeignKey(x => x.IdAlbum)
            .HasConstraintName("Utwor_AlbumAPBD")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .ToTable("UtworAPBD");
    }
}