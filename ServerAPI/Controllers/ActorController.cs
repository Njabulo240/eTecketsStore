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


[HttpGet("{id}", Name = "ActorById")]
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


[HttpPost]
public IActionResult CreateActor([FromBody]ActorForCreationDto actor)
{
    try
    {
        if (actor is null)
        {
            _logger.LogError("Actor object sent from client is null.");
            return BadRequest("Actor object is null");
        }
        if (!ModelState.IsValid)
        {
            _logger.LogError("Invalid Actor object sent from client.");
            return BadRequest("Invalid model object");
        }
        var actorEntity = _mapper.Map<Actor>(actor);
        _repository.Actor.CreateActor(actorEntity);
        _repository.Save();
        var createdActor = _mapper.Map<ActorDto>(actorEntity);
        return CreatedAtRoute("ActorById", new { id = createdActor.Id }, createdActor);
    }
    catch (Exception ex)
    {
        _logger.LogError($"Something went wrong inside CreateActor action: {ex.Message}");
        return StatusCode(500, "Internal server error");
    }
}






    }
}
