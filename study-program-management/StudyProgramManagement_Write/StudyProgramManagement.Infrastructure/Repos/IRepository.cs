namespace StudyProgramManagement.Infrastructure.Repos;

public interface IRepository<T>
{
    public Task<List<T>> Get();
    public Task<T?> GetById(Guid guid);
    public void Create(T model);
    public T Update(T model);
    public void Delete(Guid guid);

}