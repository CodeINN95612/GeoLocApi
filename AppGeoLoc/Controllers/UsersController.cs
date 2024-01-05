using AppGeoLoc.Data;
using AppGeoLoc.Data.Models;
using AppGeoLoc.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppGeoLoc.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly GeoDBContext _context;

    public UsersController(GeoDBContext context)
    {
        _context = context;
    }

    [HttpGet("{name}")]
    public async Task<ActionResult<UserDto>> GetUserByName(string name)
    {
        var user = await _context.Users
            .Where(u => u.Nombre.Contains(name) || u.Apellido.Contains(name) || u.Usuario.Contains(name))
            .FirstOrDefaultAsync();

        if (user is null)
        {
            return NotFound();
        }

        using HttpClient client = new HttpClient();
        var location = await client.GetFromJsonAsync<Location>($"https://geocode.xyz/{user.Ciudad}?json=1&auth=208961614675204206403x49436");

        if (location is null)
        {
            return NotFound();
        }

        var usuario = new UserDto
        {
            Id = user.Id,
            Apellido = user.Apellido,
            Nombre = user.Nombre,
            Usuario = user.Usuario,
            Ciudad = user.Ciudad,
            Pais = location.Standard.CountryName,
            Latitud = location.Latt,
            Longitud = location.Longt
        };

        await InsertLocation(location);

        return usuario;
    }

    private async Task InsertLocation(Location location)
    {
        var existente = await _context.Cities.FirstOrDefaultAsync(c => c.Ciudad == location.Standard.City);
        if (existente is null)
        {
            _context.Cities.Add(new()
            {
                Ciudad = location.Standard.City,
                Latitud=location.Latt,
                Longitud=location.Longt,
                Pais = location.Standard.CountryName
            });
            await _context.SaveChangesAsync();
        }
    }
}
