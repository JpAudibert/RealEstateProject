namespace RealEstateBackend.EF.Interfaces
{
    public interface IRepository <T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);
        Task<T> Create(T type);
        Task CreateMany(IEnumerable<T> entities);
        Task<T> Update(T type, Guid id);
        Task Delete(Guid id);
    }
}
