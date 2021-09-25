using FilmesAPI.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FilmesAPI
{
    [DependsOn(
        typeof(FilmesAPIEntityFrameworkCoreTestModule)
        )]
    public class FilmesAPIDomainTestModule : AbpModule
    {

    }
}