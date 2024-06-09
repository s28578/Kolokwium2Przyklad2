namespace WebApplication1.DTO;

public class MuzykPostDTO
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string? Pseudonim { get; set; }
    
    public virtual ICollection<UtworDTO> Utwory { get; set; } = new List<UtworDTO>();
}