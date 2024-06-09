namespace WebApplication1.DTO;

public class MuzykDTO
{
    public int IdMuzyk { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string? Pseudonim { get; set; }
    
    public virtual ICollection<UtworDTO> UtworDtos { get; set; } = new List<UtworDTO>();
}