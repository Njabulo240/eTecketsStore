using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Contracts;
using ServerAPI.Entities.DataTransferObjects;
using ServerAPI.Entities.Models;

namespace ServerAPI.Controllers
{
    [Route("api/cinema")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
          private IMapper _mapper;
        public CinemaController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
              _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCinemas()
        {
            try
            {
                var cinemas = _repository.Cinema.GetAllCinemas();
                _logger.LogInfo($"Returned all Cinema from database.");
                 var cinemasResult = _mapper.Map<IEnumerable<CinemaDto>>(cinemas);
            return Ok(cinemasResult); 
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllCinemas action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

[HttpGet("{id}", Name = "CinemaById")]
public IActionResult GetCinemaById(Guid id)
{
    try
    {
        var cinema = _repository.Cinema.GetCinemaById(id);
        if (cinema is null)
        {
            _logger.LogError($"cinema with id: {id}, hasn't been found in db.");
            return NotFound();
        }
        else
        {
           _logger.LogInfo($"Returned cinema with id: {id}");
           var cinemaResult = _mapper.Map<CinemaDto>(cinema);
           return Ok(cinemaResult); 
        }
   }
   catch (Exception ex)
   {
        _logger.LogError($"Something went wrong inside GetcinemaById action: {ex.Message}");
        return StatusCode(500, "Internal server error");
   }
}





[HttpPost]
public IActionResult CreateCinema([FromBody]CinemaForCreationDto cinema)
{
    try
    {
        if (cinema is null)
        {
            _logger.LogError("cinema object sent from client is null.");
            return BadRequest("cinema object is null");
        }
        if (!ModelState.IsValid)
        {
            _logger.LogError("Invalid owner object sent from client.");
            return BadRequest("Invalid model object");
        }
        var cinemaEntity = _mapper.Map<Cinema>(cinema);
        _repository.Cinema.CreateCinema(cinemaEntity);
        _repository.Save();
        var createdCinema = _mapper.Map<CinemaDto>(cinemaEntity);
        return CreatedAtRoute("CinemaById", new { id = createdCinema.Id }, createdCinema);
    }
    catch (Exception ex)
    {
        _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
        return StatusCode(500, "Internal server error");
    }
}










    }
}
