using Microsoft.AspNetCore.Mvc;

namespace azure_deploy_api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class RandomController : ControllerBase
{
    private static readonly string[] Urls = new[]
    {
        "https://rogalmic.github.io/flight-planner/flight.html?log_units=metric", 
        "https://rogalmic.github.io/flight-planner/flight.html?log_units=nautical&z=5&lon=-97.479&lat=39.408",
        "https://rogalmic.github.io/flight-planner/flight.html?remote_tile_url=https%3A%2F%2Fmaps.wikimedia.org%2Fosm-intl%2F%7Bz%7D%2F%7Bx%7D%2F%7By%7D.png",
        "https://rogalmic.github.io/flight-planner/flight.html?remote_tile_url=https%3A%2F%2Ftiles.wmflabs.org%2Fosm-no-labels%2F%7Bz%7D%2F%7Bx%7D%2F%7By%7D.png",
        "https://rogalmic.github.io/flight-planner/flight.html?remote_tile_url=https%3A%2F%2Fsnapshots.openflightmaps.org%2Flive%2F2003%2Ftiles%2Fworld%2Fepsg3857%2Faero%2F512%2Flatest%2F%7Bz%7D%2F%7Bx%7D%2F%7By%7D.png&z=7",
        "https://rogalmic.github.io/flight-planner/flight.html?remote_tile_url=https%3A%2F%2Ftile.opentopomap.org%2F%7Bz%7D%2F%7Bx%7D%2F%7By%7D.png",
    };

    private readonly ILogger<RandomController> _logger;

    public RandomController(ILogger<RandomController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
        return Enumerable
            .Range(1, 2)
            .Select(index => Urls[Random.Shared.Next(Urls.Length)])
        .ToArray();
    }

    [HttpGet]
    public IEnumerable<string> GetMany([FromQuery]int count)
    {
        return Enumerable
            .Range(1, count)
            .Select(index => Urls[Random.Shared.Next(Urls.Length)])
        .ToArray();
    }
}
