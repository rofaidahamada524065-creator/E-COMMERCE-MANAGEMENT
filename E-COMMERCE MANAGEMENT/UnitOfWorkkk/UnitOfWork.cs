using E_COMMERCE_MANAGEMENT.Data;
using E_COMMERCE_MANAGEMENT.Repos.Interface;

namespace E_COMMERCE_MANAGEMENT.UnitOfWorkkk
{
    public class UnitOfWork : IUnitOWork
    {
        private readonly AppDbcontext _dbcontext;
        public UnitOfWork(AppDbcontext appDbcontext,IUserCustom userCusr,ICatigoryCustom catigoryCustom,IProductCustom productcustom,IOrdeCustom ordeCustom) 
        {
            _dbcontext = appDbcontext;
            user=userCusr;
            catigory=catigoryCustom;
            product = productcustom;
            orde = ordeCustom;
        }
        public IUserCustom user { get; }

        public ICatigoryCustom catigory { get; }

        public IProductCustom product { get; }

        public IOrdeCustom orde { get; }

        public async Task<int> SaveChangeAsync()
        {
            return await _dbcontext.SaveChangesAsync();
        }
    }
}
