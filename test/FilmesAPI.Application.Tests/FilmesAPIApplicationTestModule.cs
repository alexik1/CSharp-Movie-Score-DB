using Volo.Abp.Modularity;

namespace FilmesAPI
{
    [DependsOn(
        typeof(FilmesAPIApplicationModule),
        typeof(FilmesAPIDomainTestModule)
        )]
    public class FilmesAPIApplicationTestModule : AbpModule
    {

    }
}