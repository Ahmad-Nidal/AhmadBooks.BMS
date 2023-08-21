using AhmadBooks.BMS.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AhmadBooks.BMS;

[DependsOn(
    typeof(BMSEntityFrameworkCoreTestModule)
    )]
public class BMSDomainTestModule : AbpModule
{

}
