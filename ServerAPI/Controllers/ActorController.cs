using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Contracts;
using ServerAPI.Entities.DataTransferObjects;
using ServerAPI.Entities.Models;

namespace ServerAPI.Controllers
{
    [Route("api/actor")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public ActorController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
                _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllActors()
        {
            try
            {
                var actors = _repository.Actor.GetAllActors();
                _logger.LogInfo($"Returned all Actor from database.");

            var actorsResult = _mapper.Map<IEnumerable<ActorDto>>(actors);
            return Ok(actorsResult); 
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllActors action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


[HttpGet("{id}")]
public IActionResult GetActorById(Guid id)
{
    try
    {
        var actor = _repository.Actor.GetActorById(id);
        if (actor is null)
        {
            _logger.LogError($"actor with id: {id}, hasn't been found in db.");
            return NotFound();
        }
        else
        {
           _logger.LogInfo($"Returned actor with id: {id}");
           var actorResult = _mapper.Map<ActorDto>(actor);
           return Ok(actorResult); 
        }
   }
   catch (Exception ex)
   {
        _logger.LogError($"Something went wrong inside GetactorById action: {ex.Message}");
        return StatusCode(500, "Internal server error");
   }
}









    }
}
