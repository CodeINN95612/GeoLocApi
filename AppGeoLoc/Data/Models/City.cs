using System.ComponentModel.DataAnnotations;

namespace AppGeoLoc.Data.Models;

public class City
{
    [Key]
    public required string Ciudad { get; set; }
    public required string Pais { get; set; }
    public required string Longitud { get; set; }
    public required string Latitud { get; set; }
}
