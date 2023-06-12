using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace APIService.Controllers;

[ApiController]
[Route("[controller]")]
public class CitiesController : ControllerBase
{
    private readonly ILogger<CitiesController> _logger;
    private readonly IConfiguration configuration;

    public CitiesController(ILogger<CitiesController> logger, IConfiguration configuration)
    {
        _logger = logger;
        this.configuration = configuration;
    }

    [HttpGet(Name = "GetCities")]
    public async Task<ActionResult<List<City>>> GetCities()
    {

        var response = new List<City>();

        response = await GetAsync();
        return response;

    }

    private async Task<List<City>> GetAsync()
    {
        var port = configuration.GetValue("port",27017);
        var host = configuration["host"];
        var dbName = configuration.GetValue("db-name","Cities");
        var colletionName = configuration.GetValue("colletion-name","Cities");
        var un = configuration["username"];
        var password = configuration["password"];
        var mongoClient = new MongoClient(
                    $"mongodb://{un}:{password}@{host}:{port}/");

        var mongoDatabase = mongoClient.GetDatabase(
            dbName);

        var _booksCollection = mongoDatabase.GetCollection<City>(
            colletionName);
        return await _booksCollection.Find(_ => true).ToListAsync();

    }

}