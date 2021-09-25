using Volo.Abp.Settings;

namespace FilmesAPI.Settings
{
    public class FilmesAPISettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(FilmesAPISettings.MySetting1));
        }
    }
}
