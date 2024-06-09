namespace WebApplication1.Models;

public class WytworniaAPBD
{
    public int IdWytwornia { get; set; }
    public string Nazwa { get; set; }
    
    public virtual ICollection<AlbumAPBD> Albumy { get; set; } = new List<AlbumAPBD>();
}