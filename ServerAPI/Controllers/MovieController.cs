using Microsoft.AspNetCore.Mvc;
using ServerAPI.Contracts;

namespace ServerAPI.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        public MovieController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            try
            {
                var movies = _repository.Movie.GetAllMovies();
                _logger.LogInfo($"Returned all Movie from database.");
                return Ok(movies);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllMovies action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
