using enerweb.FullStackTest.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace enerweb.FullStackTest.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(FullStackTestEntityFrameworkCoreModule),
        typeof(FullStackTestApplicationContractsModule)
        )]
    public class FullStackTestDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
