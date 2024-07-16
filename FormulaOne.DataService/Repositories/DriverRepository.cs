using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;

public class DriverRepository(AppDbContext context, ILogger logger)
    : GenericRepository<Driver>(context, logger),
        IDriverRepository
{
    public override async Task<IEnumerable<Driver>> All()
    {
        try
        {
            return await _dbSet
                .Where(d => d.Status == 1)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(d => d.AddedDate)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} All function error", typeof(DriverRepository));
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            var driver = await _dbSet.FirstOrDefaultAsync(d => d.Id == id);

            if (driver is null)
            {
                return false;
            }

            driver.Status = 0;
            driver.UpdatedDate = DateTime.UtcNow;

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Delete function error", typeof(DriverRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Driver entity)
    {
        try
        {
            var driver = await _dbSet.FirstOrDefaultAsync(d => d.Id == entity.Id);

            if (driver is null)
            {
                return false;
            }

            driver.UpdatedDate = DateTime.UtcNow;
            driver.DriverNumber = entity.DriverNumber;
            driver.FirstName = entity.FirstName;
            driver.LastName = entity.LastName;
            driver.DateOfBirth = entity.DateOfBirth;

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Update function error", typeof(DriverRepository));
            throw;
        }
    }
}
