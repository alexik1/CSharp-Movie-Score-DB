using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace FilmesAPI.Data
{
    /* This is used if database provider does't define
     * IFilmesAPIDbSchemaMigrator implementation.
     */
    public class NullFilmesAPIDbSchemaMigrator : IFilmesAPIDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}