using ServerAPI.Contracts;
using ServerAPI.Entities.Models;

namespace ServerAPI.Repository
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        public MovieRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}