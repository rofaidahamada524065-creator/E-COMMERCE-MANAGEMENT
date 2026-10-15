using E_COMMERCE_MANAGEMENT.DTOs.Order;
using E_COMMERCE_MANAGEMENT.Model;

namespace E_COMMERCE_MANAGEMENT.Repos.Interface
{
    public interface IOrdeCustom:IGenaricRepo<Order>
    {
        Task<TotalAmounDto?> GetOrder(int id);
        Task<OrderRevenuo?> Revenio();
    }
}
