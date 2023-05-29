namespace TestManagement.Infrastructure.Repo;

public interface IReadRepository<T>
{
    public Task<List<T>> Get();
    public Task<T?> GetById(Guid guid);
}