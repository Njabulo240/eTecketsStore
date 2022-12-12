using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Contracts;
using ServerAPI.Entities.DataTransferObjects;

namespace ServerAPI.Controllers
{
   [Route("api/producer")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
         private IMapper _mapper;
        public ProducerController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
               _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllProducers()
        {
            try
            {
                var producers = _repository.Producer.GetAllProducers();
                _logger.LogInfo($"Returned all Producers from database.");


                  var producersResult = _mapper.Map<IEnumerable<ProducerDto>>(producers);
            return Ok(producersResult); 
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllProducers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

[HttpGet("{id}")]
public IActionResult GetProducerById(Guid id)
{
    try
    {
        var producer = _repository.Producer.GetProducerById(id);
        if (producer is null)
        {
            _logger.LogError($"producer with id: {id}, hasn't been found in db.");
            return NotFound();
        }
        else
        {
           _logger.LogInfo($"Returned owner with id: {id}");
           var producerResult = _mapper.Map<ProducerDto>(producer);
           return Ok(producerResult); 
        }
   }
   catch (Exception ex)
   {
        _logger.LogError($"Something went wrong inside GetProducerById action: {ex.Message}");
        return StatusCode(500, "Internal server error");
   }
}



    }
}
