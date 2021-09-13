using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using enerweb.FullStackTest.Data;
using Volo.Abp.DependencyInjection;

namespace enerweb.FullStackTest.EntityFrameworkCore
{
    public class EntityFrameworkCoreFullStackTestDbSchemaMigrator
        : IFullStackTestDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreFullStackTestDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the FullStackTestDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<FullStackTestDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
