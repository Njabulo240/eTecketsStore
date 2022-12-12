using Microsoft.AspNetCore.Mvc;
using ServerAPI.Contracts;

namespace ServerAPI.Controllers
{
    [Route("api/cinema")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        public CinemaController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAllCinemas()
        {
            try
            {
                var cinemas = _repository.Cinema.GetAllCinemas();
                _logger.LogInfo($"Returned all Cinema from database.");
                return Ok(cinemas);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllCinemas action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
