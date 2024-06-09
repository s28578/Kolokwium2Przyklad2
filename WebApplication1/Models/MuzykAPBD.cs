namespace WebApplication1.Models;

public class MuzykAPBD
{
    public int IdMuzyk { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string? Pseudonim { get; set; }
    
    public virtual ICollection<WykonawcaUtworuAPBD> WykonawcaUtworow { get; set; } = new List<WykonawcaUtworuAPBD>();
}