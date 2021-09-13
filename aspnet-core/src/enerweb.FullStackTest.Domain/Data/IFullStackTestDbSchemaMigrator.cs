using System.Threading.Tasks;

namespace enerweb.FullStackTest.Data
{
    public interface IFullStackTestDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
