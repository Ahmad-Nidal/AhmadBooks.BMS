using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AhmadBooks.BMS.Data;

/* This is used if database provider does't define
 * IBMSDbSchemaMigrator implementation.
 */
public class NullBMSDbSchemaMigrator : IBMSDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
