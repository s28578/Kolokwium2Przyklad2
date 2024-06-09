using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configs;

public class AlbumAPBDConfig: IEntityTypeConfiguration<AlbumAPBD>
{
    public void Configure(EntityTypeBuilder<AlbumAPBD> builder)
    {
        builder
            .HasKey(bs => bs.IdAlbum)
            .HasName("AlbumAPBD_pk");
        
        builder
            .Property(x => x.NazwaAlbumu)
            .IsRequired()
            .HasMaxLength(30);
        builder
            .Property(x => x.DataWydania)
            .IsRequired();
        builder
            .HasOne(x => x.WytworniaAPBD)
            .WithMany(x => x.Albumy)
            .HasForeignKey(x => x.IdWytwornia)
            .HasConstraintName("Album_WytworniaAPBD")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .ToTable("AlbumAPBD");
    }
}