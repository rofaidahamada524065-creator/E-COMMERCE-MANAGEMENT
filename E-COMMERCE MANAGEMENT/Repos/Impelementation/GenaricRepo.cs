using E_COMMERCE_MANAGEMENT.Data;
using E_COMMERCE_MANAGEMENT.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace E_COMMERCE_MANAGEMENT.Repos.Impelementation
{
    public class GenaricRepo<T> : IGenaricRepo<T> where T : class
    {
        private readonly AppDbcontext _context;
        public DbSet<T> db;
        public GenaricRepo(AppDbcontext appDbcontext)
        {
            _context=appDbcontext;
            db=_context.Set<T>();
        }
        public async Task Create(T enete)
        {
           await db.AddAsync(enete);
        }

        public void Delete(int id)
        {
            var x = db.Find(id);
            if (x != null)
            {
                db.Remove(x);
            }
        }

        public async Task<T> GeetById(int id)
        {
            return await db.FindAsync(id);
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await db.ToListAsync();
        }

        public void Update(T ente)
        {
            db.Update(ente);
        }
    }
}
