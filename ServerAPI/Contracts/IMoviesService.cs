using ServerAPI.Entities.Models;

namespace ServerAPI.Contracts
{
 public interface IMoviesService:IEntityBaseRepository<Movie>
    {
        // Task<Movie> GetMovieByIdAsync(int id);
        // Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        //  Task AddNewMovieAsync(NewMovieVM data);
        //   Task UpdateMovieAsync(NewMovieVM data);
     
    }
}