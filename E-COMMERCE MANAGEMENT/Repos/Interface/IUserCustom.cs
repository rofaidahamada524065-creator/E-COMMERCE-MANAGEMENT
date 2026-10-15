using E_COMMERCE_MANAGEMENT.Model;

namespace E_COMMERCE_MANAGEMENT.Repos.Interface
{
    public interface IUserCustom:IGenaricRepo<User>
    {
        Task<User> GetByEmail(string  Email);
    }
}
