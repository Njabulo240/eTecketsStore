using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Contracts;
using ServerAPI.Entities.DataTransferObjects;
using ServerAPI.Entities.Models;

namespace ServerAPI.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
         private IMapper _mapper;
        public MovieController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
               _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            try
            {
                var movies = _repository.Movie.GetAllMovies();
                _logger.LogInfo($"Returned all Movie from database.");
               var moviesResult = _mapper.Map<IEnumerable<MovieDto>>(movies);
            return Ok(moviesResult); 
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllMovies action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


[HttpGet("{id}", Name = "MovieById")]
public IActionResult GetMovieById(Guid id)
{
    try
    {
        var movie = _repository.Movie.GetMovieById(id);
        if (movie is null)
        {
            _logger.LogError($" movie with id: {id}, hasn't been found in db.");
            return NotFound();
        }
        else
        {
           _logger.LogInfo($"Returned movie with id: {id}");
           var movieResult = _mapper.Map<MovieDto>(movie);
           return Ok(movieResult); 
        }
   }
   catch (Exception ex)
   {
        _logger.LogError($"Something went wrong inside GetmovieById action: {ex.Message}");
        return StatusCode(500, "Internal server error");
   }
}









[HttpGet("{id}/actor")]
public IActionResult GetOwnerWithDetails(Guid id)
{
    try
    {
        var owner = _repository.Movie.GetMovieByIdDetails(id);
        if (owner == null)
        {
            _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
            return NotFound();
        }
        else
        {
            _logger.LogInfo($"Returned owner with details for id: {id}");
            
            var ownerResult = _mapper.Map<MovieDto>(owner);
            return Ok(ownerResult);
        }
    }
    catch (Exception ex)
    {
        _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
        return StatusCode(500, "Internal server error");
    }
}



[HttpPost]
public IActionResult CreateMovie([FromBody]MovieForCreationDto movie)
{
    try
    {
        if (movie is null)
        {
            _logger.LogError("movie object sent from client is null.");
            return BadRequest("movie object is null");
        }
        if (!ModelState.IsValid)
        {
            _logger.LogError("Invalid owner object sent from client.");
            return BadRequest("Invalid model object");
        }
        var movieEntity = _mapper.Map<Movie>(movie);
        _repository.Movie.CreateMovieAsync(movieEntity);
        _repository.Save();
        var createdMovie = _mapper.Map<MovieDto>(movieEntity);
        return CreatedAtRoute("MovieById", new { id = createdMovie.Id }, createdMovie);
    }
    catch (Exception ex)
    {
        _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
        return StatusCode(500, "Internal server error");
    }
}






    }
}
