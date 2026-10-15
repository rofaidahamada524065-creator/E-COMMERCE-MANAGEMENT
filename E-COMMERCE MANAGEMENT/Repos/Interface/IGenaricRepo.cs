namespace E_COMMERCE_MANAGEMENT.Repos.Interface
{
    public interface IGenaricRepo<T> where T : class
    {
        void Delete(int id);
        void Update(T ente);
        Task Create(T enete);
        Task<T> GeetById(int id);
        Task<ICollection<T>> GetAll();
    }
}
