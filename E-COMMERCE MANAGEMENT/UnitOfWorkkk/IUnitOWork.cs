using E_COMMERCE_MANAGEMENT.Repos.Interface;

namespace E_COMMERCE_MANAGEMENT.UnitOfWorkkk
{
    public interface IUnitOWork
    {
        IUserCustom user { get; }
        ICatigoryCustom catigory { get; }
        IProductCustom product { get; }

        IOrdeCustom orde { get; }
        Task<int> SaveChangeAsync();
    }
}
