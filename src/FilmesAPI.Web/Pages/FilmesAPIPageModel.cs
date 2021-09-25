using FilmesAPI.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FilmesAPI.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class FilmesAPIPageModel : AbpPageModel
    {
        protected FilmesAPIPageModel()
        {
            LocalizationResourceType = typeof(FilmesAPIResource);
        }
    }
}