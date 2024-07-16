using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;

public class GenericRepository<T>(AppDbContext context, ILogger logger) : IGenericRepository<T>
    where T : class
{
    public readonly ILogger _logger = logger;
    protected AppDbContext _context = context;
    internal DbSet<T> _dbSet = context.Set<T>();

    public async Task<bool> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        return true;
    }

    public Task<IEnumerable<T>> All()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<T?> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }
}
