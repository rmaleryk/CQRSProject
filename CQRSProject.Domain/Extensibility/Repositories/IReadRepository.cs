namespace CQRSProject.Domain.Extensibility.Repositories
{
    public interface IReadRepository<T>
    {
        T[] GetAll();
    }
}