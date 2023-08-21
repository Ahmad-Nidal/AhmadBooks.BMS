using AhmadBooks.BMS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AhmadBooks.BMS.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BMSController : AbpControllerBase
{
    protected BMSController()
    {
        LocalizationResource = typeof(BMSResource);
    }
}
