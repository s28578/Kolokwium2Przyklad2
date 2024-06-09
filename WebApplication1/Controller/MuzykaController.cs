using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Controller;

[Route("api/[controller]")]
[ApiController]
public class MuzykaController: ControllerBase
{
    private readonly MuzykaDbContext _dbContext;

    public MuzykaController(MuzykaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("Muzyk/{idMuzyk:int}")]
    public async Task<IActionResult> GetReservations(int idMuzyk)
    {
        MuzykAPBD muzyk = await _dbContext.MuzycyAPBD.Where(muz => muz.IdMuzyk == idMuzyk).SingleAsync();
        List<UtworAPBD> utwory = await _dbContext.UtworyAPBD.Join(
                _dbContext.WykonawcaUtworuApbds, utw => utw.IdUtwor, wyk => wyk.IdUtwor,
                ((utw, wyk) => new { utw, wyk.IdMuzyk }))
            .Where(wyk => wyk.IdMuzyk == idMuzyk).Select(x => x.utw).ToListAsync();
        List<UtworDTO> utworyDto = new List<UtworDTO>();
        foreach (UtworAPBD utwor in utwory)
        {
            utworyDto.Add(new UtworDTO
            {
                IdUtwor = utwor.IdUtwor,
                NazwaUtworu = utwor.NazwaUtworu,
                CzasTrwania = utwor.CzasTrwania
            });
        }

        MuzykDTO muzykDto = new MuzykDTO
        {
            IdMuzyk = muzyk.IdMuzyk,
            Imie = muzyk.Imie,
            Nazwisko = muzyk.Nazwisko,
            Pseudonim = muzyk.Pseudonim,
            UtworDtos = utworyDto
        };
        
        return Ok(muzykDto);
    }

    [HttpPost("DodajMuzyka")]
    //public async Task<IActionResult> GetPatients(Patient patient, Prescription prescription, Doctor doctor)
    public async Task<IActionResult> PostMuzyk(MuzykPostDTO muzykPostDto)
    {
        MuzykAPBD muzykDoDodania = new MuzykAPBD
        {
            Imie = muzykPostDto.Imie,
            Nazwisko = muzykPostDto.Nazwisko,
            Pseudonim = muzykPostDto.Pseudonim
            
        };

        foreach (var utworDto in muzykPostDto.Utwory)
        {
            await _dbContext.UtworyAPBD.AddAsync(new UtworAPBD
            {
                NazwaUtworu = utworDto.NazwaUtworu,
                CzasTrwania = utworDto.CzasTrwania,

            });
            
        }
        await _dbContext.MuzycyAPBD.AddAsync(muzykDoDodania);
        
        await _dbContext.SaveChangesAsync();
        
        return Ok();
    }

}

//INSERT INTO Patient (FirstName,LastName,Birthdate)
//VALUES ('Mark','Twain','1984-06-01 00:00:00.000'); 

// UPDATE Reservation
// SET Fulfilled = 0
// WHERE IdReservation = 1; 

// DELETE FROM Reservation WHERE IdReservation = 2;

//Money = decimal
//float = double
//date = DateTime
//bit = bool

//return StatusCode(StatusCodes.Status201Created);
// return StatusCode((int)HttpStatusCode.OK, "data");
// return Created("uri", "data");
// return ValidationProblem("message");
// return Forbid("message");
// return Challenge();
// return Accepted("data or message");
// return Unauthorized("message");
// return NotFound("Message");
// return BadRequest("Error description");
//return Ok(ret);