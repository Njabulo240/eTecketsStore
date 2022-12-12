using Microsoft.AspNetCore.Mvc;
using ServerAPI.Contracts;

namespace ServerAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private IRepositoryWrapper _repository;
    public WeatherForecastController(IRepositoryWrapper repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public IEnumerable<string> Get()
    {
        var owners = _repository.Movie.FindAll();
        return new string[] { "value1", "value2" };
    }
}