using ServerAPI.Contracts;
using ServerAPI.Entities.Models;
using ServerAPI.Repository;

namespace ServerAPI.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
              public ActorsService(RepositoryContext context) : base(context) { }
    }
}