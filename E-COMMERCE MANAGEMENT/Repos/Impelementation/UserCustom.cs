using E_COMMERCE_MANAGEMENT.Data;
using E_COMMERCE_MANAGEMENT.Model;
using E_COMMERCE_MANAGEMENT.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace E_COMMERCE_MANAGEMENT.Repos.Impelementation
{
    public class UserCustom : GenaricRepo<User>, IUserCustom
    {
        private readonly AppDbcontext _dbcontext;
        public UserCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _dbcontext = appDbcontext;
        }

        public async Task<User> GetByEmail(string Email)
        {
            return await _dbcontext.users.SingleOrDefaultAsync(a=>a.Email== Email);  
        }
    }
}
