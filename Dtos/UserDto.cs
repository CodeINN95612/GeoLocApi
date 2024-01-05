namespace AppGeoLoc.Dtos;

public class UserDto
{
    public required int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Usuario { get; set; }
    public required string Ciudad {  get; set; }
    public required string Pais { get; set; }
    public required string Latitud { get; set; }
    public required string Longitud { get; set; }
}
