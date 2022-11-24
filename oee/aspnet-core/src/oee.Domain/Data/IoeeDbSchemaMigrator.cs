using System.Threading.Tasks;

namespace oee.Data;

public interface IoeeDbSchemaMigrator
{
    Task MigrateAsync();
}
