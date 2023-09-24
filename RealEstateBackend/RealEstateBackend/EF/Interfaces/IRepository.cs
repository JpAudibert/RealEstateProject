namespace RealEstateBackend.EF.Interfaces
{
    public interface IRepository <T>
    {
        IEnumerable<T> GetAll();
        T Get();
        void Create();
        void Update();
        void Delete();
    }
}
