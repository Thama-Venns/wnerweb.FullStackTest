using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace enerweb.FullStackTest
{
    [Dependency(ReplaceServices = true)]
    public class FullStackTestBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "FullStackTest";
    }
}
