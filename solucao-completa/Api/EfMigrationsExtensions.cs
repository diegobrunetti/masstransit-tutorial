using MassTransitTutorial.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransiTutorial.Api
{
    public static class EfMigrationsExtensions
    {
        public static void ApplyDatabaseMigrations(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<CustomerContext>().Database.Migrate();
            }
        }
    }
}
