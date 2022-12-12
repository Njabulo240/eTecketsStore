using ServerAPI.Contracts;
using ServerAPI.Entities.Models;
using ServerAPI.Repository;

namespace ServerAPI.Services
{
    public class ProducersService: EntityBaseRepository<Producer>, IProducersService
    {
         public ProducersService(RepositoryContext context) : base(context)
        {
        }
    }
}