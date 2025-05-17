using Homework_SkillTree.Api.Context;
using Homework_SkillTree.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Homework_SkillTree.Infrastructure;

public class Repository<T>(SkillTreeHomeworkDbContext context) : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();
    
    public IQueryable<T> FindAsQueryable() => _dbSet.AsQueryable().AsNoTracking();
    
    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
    
    public async Task AddRangeAsync(IEnumerable<T> entities) => await _dbSet.AddRangeAsync(entities);
    
    public void Update(T entity) => _dbSet.Update(entity);
    
    public void UpdateRange(IEnumerable<T> entities) => _dbSet.UpdateRange(entities);
    
    public void Delete(T entity) => _dbSet.Remove(entity);
    
    public void DeleteRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);
    
    public async Task<int> GetCountAsync() => await _dbSet.CountAsync();
    
    public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();
}