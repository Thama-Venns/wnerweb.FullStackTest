using enerweb.FullStackTest.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace enerweb.FullStackTest
{
    [DependsOn(
        typeof(FullStackTestEntityFrameworkCoreTestModule)
        )]
    public class FullStackTestDomainTestModule : AbpModule
    {

    }
}