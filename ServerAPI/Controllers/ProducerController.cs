using Microsoft.AspNetCore.Mvc;
using ServerAPI.Contracts;

namespace ServerAPI.Controllers
{
   [Route("api/producer")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        public ProducerController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAllProducers()
        {
            try
            {
                var producers = _repository.Producer.GetAllProducers();
                _logger.LogInfo($"Returned all Producers from database.");
                return Ok(producers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllProducers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
