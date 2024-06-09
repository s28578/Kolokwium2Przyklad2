namespace WebApplication1.Models;

public class UtworAPBD
{
    public int IdUtwor { get; set; }
    public string NazwaUtworu { get; set; }
    public double CzasTrwania { get; set; }
    public int? IdAlbum { get; set; }
    public virtual AlbumAPBD AlbumAPBD { get; set; }
    
    public virtual ICollection<WykonawcaUtworuAPBD> WykonawcaUtworow { get; set; } = new List<WykonawcaUtworuAPBD>();
}