using Volo.Abp.Settings;

namespace oee.Settings;

public class oeeSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(oeeSettings.MySetting1));
    }
}
