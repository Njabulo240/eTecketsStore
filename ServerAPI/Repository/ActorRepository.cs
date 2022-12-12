using ServerAPI.Contracts;
using ServerAPI.Entities.Models;

namespace ServerAPI.Repository
{
    public class ActorRepository : RepositoryBase<Actor>, IActorRepository
    {
        public ActorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Actor> GetAllActors()
        {
                      return FindAll()
                .OrderBy(ow => ow.ProfilePictureURL)
                .ToList();
        }
    }
}