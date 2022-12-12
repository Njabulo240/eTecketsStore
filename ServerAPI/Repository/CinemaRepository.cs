using ServerAPI.Contracts;
using ServerAPI.Entities.Models;

namespace ServerAPI.Repository
{
    public class CinemaRepository : RepositoryBase<Cinema>, ICinemaRepository
    {
        public CinemaRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Cinema> GetAllCinemas()
        {
              return FindAll()
                .OrderBy(ow => ow.Logo)
                .ToList();
        }
    }
}