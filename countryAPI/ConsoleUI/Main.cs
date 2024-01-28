
using countryAPI.models;
using Newtonsoft.Json;
using Spectre.Console;
namespace countryAPI.ConsoleUI;

public class MainMenu
{
    private string rigionspath = "https://countryapi-fcn9.onrender.com/viloyatlar";
    private string citiespath = "https://countryapi-fcn9.onrender.com/shaxarlar";
    private string placespath = "https://countryapi-fcn9.onrender.com/joylar";

    private HttpClient httpClientcities;
    private HttpClient httpClientregions;
    private HttpClient httpClientplaces;

    private List<CityModel> cityList;
    private List<RegionModel> regionList;
    private List<PlaceModel> placeList;

    public MainMenu()
    {
        httpClientcities = new HttpClient();
        httpClientregions = new HttpClient();
        httpClientplaces = new HttpClient();

        httpClientcities.BaseAddress = new Uri(placespath);
        httpClientregions.BaseAddress = new Uri(placespath);
        httpClientplaces.BaseAddress = new Uri(placespath);
    }

    public async Task GetDataAsync()
    {
        var citiesResponse = await httpClientcities.GetAsync(citiespath);
        var regionsResponse = await httpClientregions.GetAsync(rigionspath);
        var placesResponse = await httpClientplaces.GetAsync(placespath);


        var citiesData = await citiesResponse.Content.ReadAsStringAsync();
        var regionsData = await regionsResponse.Content.ReadAsStringAsync();
        var placesData = await placesResponse.Content.ReadAsStringAsync();

        cityList = JsonConvert.DeserializeObject<List<CityModel>>(citiesData);
        regionList = JsonConvert.DeserializeObject<List<RegionModel>>(regionsData);
        placeList = JsonConvert.DeserializeObject<List<PlaceModel>>(placesData);
    }


    public void Display()
    {
        AnsiConsole.Write(new Markup("[green]\n\nPlaces list[/]\n\n"));
        var cCount = true;
        while (cCount)
        {
            if (cityList != null)
            {
                foreach (CityModel city in cityList)
                {
                    Console.WriteLine($"ID: {city.Id}|\n" +
                        $"Name: {city.Name}|\n" +
                        $"Description: {city.Description}|");
                }
                break;
            }
        }

        AnsiConsole.Write(new Markup("[green]\n\nRegion list[/]\n\n"));
        var rCount = true;
        while (rCount)
        {
            if (regionList != null)
            {
                foreach (RegionModel region in regionList)
                {
                    Console.WriteLine($"ID: {region.Id}|\n" +
                        $"Name: {region.Name}|\n" +
                        $"Description: {region.Description}|");
                }
                break;

            }
        }
        AnsiConsole.Write(new Markup("[green]\n\nPlaces list[/]\n\n"));
        var pCount = true;
        while (pCount)
        {
            if (regionList != null)
            {
                foreach (PlaceModel places in placeList)
                {
                    Console.WriteLine($"ID: {places.Id}|\n" +
                        $"Name: {places.Name}|\n" +
                        $"Description: {places.Description}|");
                   
                }

                break;
            }
        }
    }
}

