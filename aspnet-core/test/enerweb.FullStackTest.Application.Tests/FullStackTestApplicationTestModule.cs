using Volo.Abp.Modularity;

namespace enerweb.FullStackTest
{
    [DependsOn(
        typeof(FullStackTestApplicationModule),
        typeof(FullStackTestDomainTestModule)
        )]
    public class FullStackTestApplicationTestModule : AbpModule
    {

    }
}