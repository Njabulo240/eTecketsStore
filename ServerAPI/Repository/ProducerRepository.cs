using ServerAPI.Contracts;
using ServerAPI.Entities.Models;

namespace ServerAPI.Repository
{
    public class ProducerRepository : RepositoryBase<Producer>, IProducerRepository
    {
        public ProducerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}