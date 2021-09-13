using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace enerweb.FullStackTest.Data
{
    /* This is used if database provider does't define
     * IFullStackTestDbSchemaMigrator implementation.
     */
    public class NullFullStackTestDbSchemaMigrator : IFullStackTestDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}