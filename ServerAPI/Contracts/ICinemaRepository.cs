using ServerAPI.Entities.Models;

namespace ServerAPI.Contracts
{
    public interface ICinemaRepository :IRepositoryBase<Cinema>
    {
     IEnumerable<Cinema> GetAllCinemas();
    Cinema GetCinemaById(Guid cinemaId);
    Cinema GetCinemaWithDetails(Guid cinemaId);
    void CreateCinema(Cinema cinema);
    }
}