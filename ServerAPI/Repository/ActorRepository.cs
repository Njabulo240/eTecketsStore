using ServerAPI.Contracts;
using ServerAPI.Entities.Models;

namespace ServerAPI.Repository
{
    public class ActorRepository : RepositoryBase<Actor>, IActorRepository
    {
        public ActorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateActor(Actor actor)
        {
            Create(actor);
        }

        public Actor GetActorById(Guid actorId)
        {
             return FindByCondition(actor => actor.Id.Equals(actorId))
            .FirstOrDefault();
        }

        public Actor GetActorWithDetails(Guid actorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Actor> GetAllActors()
        {
                      return FindAll()
                .OrderBy(ow => ow.ProfilePictureURL)
                .ToList();
        }
    }
}