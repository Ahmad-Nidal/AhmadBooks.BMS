using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace AhmadBooks.BMS.Web;

[Dependency(ReplaceServices = true)]
public class BMSBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BMS";
}
