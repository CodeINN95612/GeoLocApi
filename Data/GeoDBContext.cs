using AppGeoLoc.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AppGeoLoc.Data;

public class GeoDBContext : DbContext
{
    public GeoDBContext(DbContextOptions<GeoDBContext> options) :
        base(options)
    {

    }

    public virtual DbSet<User> Users { get; set; } = default!;
    public virtual DbSet<City> Cities { get; set; } = default!;
}
