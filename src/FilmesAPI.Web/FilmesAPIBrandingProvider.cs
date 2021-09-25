using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FilmesAPI.Web
{
    [Dependency(ReplaceServices = true)]
    public class FilmesAPIBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "FilmesAPI";
    }
}
