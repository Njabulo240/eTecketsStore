using Microsoft.AspNetCore.Mvc;
using ServerAPI.Contracts;

namespace ServerAPI.Controllers
{
    [Route("api/actor")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        public ActorController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAllActors()
        {
            try
            {
                var actors = _repository.Actor.GetAllActors();
                _logger.LogInfo($"Returned all Actor from database.");
                return Ok(actors);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllActors action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
