using ServerAPI.Entities.Models;

namespace ServerAPI.Contracts
{
  public interface IOrdersService
    {
       Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
     Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}