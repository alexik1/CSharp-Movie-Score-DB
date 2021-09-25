using System.Threading.Tasks;

namespace FilmesAPI.Data
{
    public interface IFilmesAPIDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
