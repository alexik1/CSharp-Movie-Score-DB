using FilmesAPI.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace FilmesAPI.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(FilmesAPIEntityFrameworkCoreModule),
        typeof(FilmesAPIApplicationContractsModule)
        )]
    public class FilmesAPIDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
