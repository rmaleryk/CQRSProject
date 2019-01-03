namespace CQRSProject.Domain.Extensibility.Repositories
{
    public interface IWriteRepository<T>
    {
        void Save(T entity);
    }
}