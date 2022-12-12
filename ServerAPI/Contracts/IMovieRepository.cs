using ServerAPI.Entities.Models;

namespace ServerAPI.Contracts
{
    public interface IMovieRepository : IRepositoryBase<Movie>
    {
         IEnumerable<Movie> GetAllMovies();
    Movie GetMovieById(Guid movieId);
   Movie GetMovieByIdDetails(Guid movieId);
    void CreateMovie(Movie movie);
    }
}