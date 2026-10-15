using System.Linq;
using E_COMMERCE_MANAGEMENT.Data;
using E_COMMERCE_MANAGEMENT.Model;
using E_COMMERCE_MANAGEMENT.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace E_COMMERCE_MANAGEMENT.Repos.Impelementation
{
    public class CatigoryCustom : GenaricRepo<Category>, ICatigoryCustom
    {
        private readonly AppDbcontext _dbcontext;
        public CatigoryCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _dbcontext = appDbcontext;
        }

       
    }
}
