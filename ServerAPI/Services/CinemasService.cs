using ServerAPI.Contracts;
using ServerAPI.Entities.Models;
using ServerAPI.Repository;

namespace ServerAPI.Services
{
   public class CinemasService:EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(RepositoryContext context) : base(context)
        {
        }  
    }
}