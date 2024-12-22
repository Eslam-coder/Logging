namespace BuildingBlocks.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyCollection<T>> GetAllAsync();

        void Add(T entity);
    }
}
