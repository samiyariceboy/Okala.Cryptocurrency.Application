using Microsoft.EntityFrameworkCore;
using Okala.Cryptocurrency.Application.DataInitializer;
using Okala.Cryptocurrency.Infrastructure.DbContexts.Sql.SqlServer;

namespace VoipService.Api.Configuration
{
    public static class SeedDatabaseConfiguration
    {
        public static async void SeedDatabase(this IApplicationBuilder app, IHostEnvironment env)
        {
            using var Scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var DbContext = Scope.ServiceProvider.GetService<ApplicationDbContext>();
            if (env.IsProduction().Equals(true))
                DbContext?.Database.EnsureCreated();
            else
                DbContext?.Database.Migrate();
            var DataInitializers = Scope.ServiceProvider
                .GetServices<IDataInitializer>().OrderBy(C => C.SortNumber);
            foreach (var DataInitializer in DataInitializers)
                await DataInitializer.InitializeData();
        }
    }
}