namespace CQS.Queries;

public interface IQueryFactory
{
    T? ResolveQuery<T>()
        where T : class, IQuery;
}