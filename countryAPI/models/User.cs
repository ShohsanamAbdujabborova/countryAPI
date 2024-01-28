namespace countryAPI.models;
public class UserModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public PlaceModel SavedPlaces { get; set; }
    public CityModel SavedCities { get; set; }
    public RegionModel SavedRegions { get; set; }
}

