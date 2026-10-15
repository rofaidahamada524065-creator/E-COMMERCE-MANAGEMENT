using E_COMMERCE_MANAGEMENT.Data;
using E_COMMERCE_MANAGEMENT.Model;
using E_COMMERCE_MANAGEMENT.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace E_COMMERCE_MANAGEMENT.Repos.Impelementation
{
    public class ProductCustom : GenaricRepo<Product>, IProductCustom
    {
        private readonly AppDbcontext _dbcontext;
        public ProductCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _dbcontext = appDbcontext;
        }

        public async Task<ICollection<Product>> most_expensive(int catigoryId)
        {

            return await _dbcontext.products.Where(a => a.CatgoryID != catigoryId).OrderByDescending(a => a.Price).Skip(1).Take(1).ToListAsync();
        }

        public async Task<ICollection<Product>> Pagination(int? categoryId, int pageNumber, int pageSize)
        {
            IQueryable<Product> qoer = _dbcontext.products.Include(a=>a.Category);
            if (categoryId.HasValue)
            {
                qoer = qoer.OrderBy(a => a.Price);

            }

            return await _dbcontext.products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();


        }

        public async Task<Product> SearchByName(string name)
        {
            return await _dbcontext.products.Where(a => a.Name.Contains(name)).FirstOrDefaultAsync();
        }
    }
}
