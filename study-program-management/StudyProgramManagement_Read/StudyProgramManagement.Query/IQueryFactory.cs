namespace StudyProgramManagement.Query;

public interface IQueryFactory
{
    T? ResolveQuery<T>()
        where T : class, IQuery;
}