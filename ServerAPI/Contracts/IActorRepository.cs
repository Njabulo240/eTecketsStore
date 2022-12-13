using ServerAPI.Entities.Models;

namespace ServerAPI.Contracts
{
    public interface IActorRepository : IRepositoryBase<Actor>
    {
    IEnumerable<Actor> GetAllActors();
    Actor GetActorById(Guid actorId);
    void CreateActor(Actor actor);
    }
}