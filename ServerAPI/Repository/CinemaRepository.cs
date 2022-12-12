using ServerAPI.Contracts;
using ServerAPI.Entities.Models;

namespace ServerAPI.Repository
{
    public class CinemaRepository : RepositoryBase<Cinema>, ICinemaRepository
    {
        public CinemaRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCinema(Cinema cinema)
        {
            Create(cinema);
        }

        public IEnumerable<Cinema> GetAllCinemas()
        {
              return FindAll()
                .OrderBy(ow => ow.Logo)
                .ToList();
        }

        public Cinema GetCinemaById(Guid cinemaId)
        {
              return FindByCondition(cinema => cinema.Id.Equals(cinemaId))
            .FirstOrDefault();
        }

        public Cinema GetCinemaWithDetails(Guid cinemaId)
        {
            throw new NotImplementedException();
        }
    }
}