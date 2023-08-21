using Volo.Abp.Settings;

namespace AhmadBooks.BMS.Settings;

public class BMSSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BMSSettings.MySetting1));
    }
}
