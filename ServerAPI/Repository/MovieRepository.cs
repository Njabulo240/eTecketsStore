using Microsoft.EntityFrameworkCore;
using ServerAPI.Contracts;
using ServerAPI.Entities.DataTransferObjects;
using ServerAPI.Entities.Models;

namespace ServerAPI.Repository
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public MovieRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
           _repositoryContext = repositoryContext;
        }

      

        public void CreateMovieAsync(Movie movie)
        { 
            Create(movie);
        }


        public IEnumerable<Movie> GetAllMovies()
        {
            return FindAll().OrderBy(ow => ow.Name).ToList();;
        }

        public Movie GetMovieById(Guid movieId)
        {
            return FindByCondition(movie => movie.Id.Equals(movieId)).FirstOrDefault();
        }

        public Movie GetMovieByIdDetails(Guid movieId)
        {
            return FindByCondition(movie => movie.Id.Equals(movieId))
            .Include(ac => ac.Actors_Movies)
            .FirstOrDefault();
        }

 
    }
}