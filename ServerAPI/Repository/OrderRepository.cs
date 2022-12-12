using ServerAPI.Contracts;
using ServerAPI.Entities.Models;

namespace ServerAPI.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}