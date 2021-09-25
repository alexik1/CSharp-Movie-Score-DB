using System;
using System.Collections.Generic;
using System.Text;
using FilmesAPI.Localization;
using Volo.Abp.Application.Services;

namespace FilmesAPI
{
    /* Inherit your application services from this class.
     */
    public abstract class FilmesAPIAppService : ApplicationService
    {
        protected FilmesAPIAppService()
        {
            LocalizationResource = typeof(FilmesAPIResource);
        }
    }
}
