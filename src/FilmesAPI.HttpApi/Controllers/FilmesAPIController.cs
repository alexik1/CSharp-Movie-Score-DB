using FilmesAPI.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class FilmesAPIController : AbpController
    {
        protected FilmesAPIController()
        {
            LocalizationResource = typeof(FilmesAPIResource);
        }
    }
}