using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;

public class AchievementsRepository(AppDbContext context, ILogger logger)
    : GenericRepository<Achievement>(context, logger),
        IAchievementsRepository
{
    public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
    {
        try
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.DriverId == driverId);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "{Repo} GetDriverAchievementAsync function error",
                typeof(AchievementsRepository)
            );
            throw;
        }
    }

    public override async Task<IEnumerable<Achievement>> All()
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
            _logger.LogError(ex, "{Repo} All function error", typeof(AchievementsRepository));
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            var achievement = await _dbSet.FirstOrDefaultAsync(a => a.Id == id);

            if (achievement is null)
            {
                return false;
            }

            achievement.Status = 0;
            achievement.UpdatedDate = DateTime.UtcNow;

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Delete function error", typeof(AchievementsRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Guid id, Achievement entity)
    {
        try
        {
            var achievement = await _dbSet.FirstOrDefaultAsync(a => a.Id == entity.Id);

            if (achievement is null)
            {
                return false;
            }

            achievement.UpdatedDate = DateTime.UtcNow;
            achievement.FastestLap = entity.FastestLap;
            achievement.PolePosition = entity.PolePosition;
            achievement.RaceWins = entity.RaceWins;
            achievement.WorldChampionship = entity.WorldChampionship;

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Update function error", typeof(AchievementsRepository));
            throw;
        }
    }
}
