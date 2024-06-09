namespace WebApplication1.Models;

public class WykonawcaUtworuAPBD
{
    public int IdMuzyk { get; set; }
    public virtual MuzykAPBD MuzykAPBD { get; set; }
    public int IdUtwor { get; set; }
    public virtual UtworAPBD UtworAPBD { get; set; }
}