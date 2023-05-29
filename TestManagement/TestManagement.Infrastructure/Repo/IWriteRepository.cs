namespace TestManagement.Infrastructure.Repo;

public interface IWriteRepository<T>
{
    public void Create(T test);
    public T Update(T test);
}