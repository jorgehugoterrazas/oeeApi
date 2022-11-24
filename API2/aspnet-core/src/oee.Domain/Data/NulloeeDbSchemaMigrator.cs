using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace oee.Data;

/* This is used if database provider does't define
 * IoeeDbSchemaMigrator implementation.
 */
public class NulloeeDbSchemaMigrator : IoeeDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
