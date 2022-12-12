using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Contracts;
using ServerAPI.Entities.DataTransferObjects;

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

[HttpGet("{id}")]
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


    }
}
