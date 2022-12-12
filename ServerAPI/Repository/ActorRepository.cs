using ServerAPI.Contracts;
using ServerAPI.Entities.Models;

namespace ServerAPI.Repository
{
    public class ActorRepository : RepositoryBase<Actor>, IActorRepository
    {
        public ActorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}