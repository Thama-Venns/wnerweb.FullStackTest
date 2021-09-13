using Volo.Abp.Settings;

namespace enerweb.FullStackTest.Settings
{
    public class FullStackTestSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(FullStackTestSettings.MySetting1));
        }
    }
}
