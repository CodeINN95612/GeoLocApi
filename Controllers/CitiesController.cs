using AppGeoLoc.Data;
using AppGeoLoc.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppGeoLoc.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : ControllerBase
{
    private readonly GeoDBContext _context;

    public CitiesController(GeoDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<City>>> GetCities()
    {
        return await _context.Cities.ToListAsync();
    }

    [HttpGet("{ciudad}")]
    public async Task<ActionResult<City>> GetCity(string ciudad)
    {
        var city = await _context.Cities.FindAsync(ciudad);

        if (city == null)
        {
            return NotFound();
        }

        return city;
    }
}
