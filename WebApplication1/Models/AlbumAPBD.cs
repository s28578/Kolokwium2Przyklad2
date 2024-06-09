namespace WebApplication1.Models;

public class AlbumAPBD
{
    public int IdAlbum { get; set; }
    public string NazwaAlbumu { get; set; }
    public DateTime DataWydania { get; set; }
    public int IdWytwornia { get; set; }
    public virtual WytworniaAPBD WytworniaAPBD { get; set; }
    
    public virtual ICollection<UtworAPBD> Utwory { get; set; } = new List<UtworAPBD>();
}