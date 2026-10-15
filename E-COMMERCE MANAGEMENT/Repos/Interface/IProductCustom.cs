using E_COMMERCE_MANAGEMENT.Model;

namespace E_COMMERCE_MANAGEMENT.Repos.Interface
{
    public interface IProductCustom:IGenaricRepo<Product>
    {
        Task<ICollection<Product>> most_expensive(int catigoryId);

        Task<ICollection<Product>> Pagination(int? categoryId, int pageNumber, int pageSize);
        Task<Product> SearchByName(string name);
    }
}
