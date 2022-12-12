using ServerAPI.Contracts;
using ServerAPI.Entities.Models;

namespace ServerAPI.Repository
{
    public class ProducerRepository : RepositoryBase<Producer>, IProducerRepository
    {
        public ProducerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateProducer(Producer producer)
        {
            Create(producer);
        }

        public IEnumerable<Producer> GetAllProducers()
        {
            return FindAll()
                .OrderBy(ow => ow.ProfilePictureURL)
                .ToList();
        }

        public Producer GetProducerById(Guid producerId)
        {
               return FindByCondition(producer => producer.Id.Equals(producerId))
            .FirstOrDefault();
        }

        public Producer GetProducerWithDetails(Guid producerId)
        {
            throw new NotImplementedException();
        }
    }
}