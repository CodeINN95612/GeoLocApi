namespace AppGeoLoc.Dtos;

public class Location
{
    public required LocationStandard Standard { get; set; }
    public required string Longt { get; set; }
    public required string Latt { get; set; }
}

public class LocationStandard
{
    public required string City { get; set; }
    public required string CountryName { get; set; }
}
