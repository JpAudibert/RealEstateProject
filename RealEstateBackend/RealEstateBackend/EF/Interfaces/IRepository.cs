using RealEstateBackend.RealEstates.Models;

namespace RealEstateBackend.EF.Interfaces
{
    public interface IRepository <T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);
        Task Create(T type);
        Task Update(T type, Guid id);
        Task Delete(Guid id);
    }
}
