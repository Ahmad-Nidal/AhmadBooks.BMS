using AhmadBooks.BMS.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AhmadBooks.BMS.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BMSEntityFrameworkCoreModule),
    typeof(BMSApplicationContractsModule)
    )]
public class BMSDbMigratorModule : AbpModule
{
}
