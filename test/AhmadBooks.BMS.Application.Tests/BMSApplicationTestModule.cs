using Volo.Abp.Modularity;

namespace AhmadBooks.BMS;

[DependsOn(
    typeof(BMSApplicationModule),
    typeof(BMSDomainTestModule)
    )]
public class BMSApplicationTestModule : AbpModule
{

}
