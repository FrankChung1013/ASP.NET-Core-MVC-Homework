namespace Homework_SkillTree.Domain.Interfaces.Repository;

public interface IRepository<T> where T : class
{
    IQueryable<T> FindAsQueryable();
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
    Task<int> GetCountAsync();
    Task<int> SaveChangesAsync();
}