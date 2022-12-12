using ServerAPI.Contracts;
using ServerAPI.Entities.Models;

namespace ServerAPI.Repository
{
    public class CinemaRepository : RepositoryBase<Cinema>, ICinemaRepository
    {
        public CinemaRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}