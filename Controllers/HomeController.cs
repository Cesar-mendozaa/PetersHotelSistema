using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SistemaApartados.Models;
using System.Diagnostics;

public class HomeController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public HomeController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    // Método para consumir la API de clima y mostrar los datos en la vista de inicio
    public async Task<IActionResult> Index()
    {
        var client = _clientFactory.CreateClient();
        var apiKey = "fb8330d85b216f0247e8748717628a6a"; 
        var city = "Chihuahua";
        var response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric");

        if (response.IsSuccessStatusCode)
        {
            var weatherData = await response.Content.ReadAsStringAsync();
            var weatherJson = JObject.Parse(weatherData);
            ViewBag.Temperature = weatherJson["main"]["temp"];
            ViewBag.Weather = weatherJson["weather"][0]["description"];
        }
        else
        {
            ViewBag.Temperature = "N/A";
            ViewBag.Weather = "N/A";
        }

        return View();
    }

    // Acción para la vista de usuario
    public IActionResult UsuarioIndex() 
    { 
        return View(); }

    // Otros métodos del controlador, si los tienes
    public IActionResult About()
    {
        ViewData["Message"] = "Your application description page.";

        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Message"] = "Your contact page.";

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
