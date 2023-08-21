using System.Threading.Tasks;

namespace AhmadBooks.BMS.Data;

public interface IBMSDbSchemaMigrator
{
    Task MigrateAsync();
}
