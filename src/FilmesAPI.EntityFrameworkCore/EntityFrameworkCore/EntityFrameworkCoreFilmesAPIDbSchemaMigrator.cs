using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FilmesAPI.Data;
using Volo.Abp.DependencyInjection;

namespace FilmesAPI.EntityFrameworkCore
{
    public class EntityFrameworkCoreFilmesAPIDbSchemaMigrator
        : IFilmesAPIDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreFilmesAPIDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the FilmesAPIDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<FilmesAPIDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
