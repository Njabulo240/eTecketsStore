using ServerAPI.Entities.Models;

namespace ServerAPI.Contracts
{
    public interface IProducerRepository: IRepositoryBase<Producer>
    {
    IEnumerable<Producer> GetAllProducers();
    Producer GetProducerById(Guid producerId);
    Producer GetProducerWithDetails(Guid producerId);
    void CreateProducer(Producer producer);
    }
}