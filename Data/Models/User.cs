using System.ComponentModel.DataAnnotations;

namespace AppGeoLoc.Data.Models;

public class User
{
    [Key]
    public required int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Usuario { get; set; }
    public required string Ciudad { get; set; }
}