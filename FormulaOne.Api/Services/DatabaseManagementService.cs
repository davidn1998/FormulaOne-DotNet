using FormulaOne.DataService.Data;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.Api.Services;

public static class DatabaseManagementService
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<AppDbContext>();
        await context.Database.MigrateAsync();
    }
}
