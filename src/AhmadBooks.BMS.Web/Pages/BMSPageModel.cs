using AhmadBooks.BMS.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AhmadBooks.BMS.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class BMSPageModel : AbpPageModel
{
    protected BMSPageModel()
    {
        LocalizationResourceType = typeof(BMSResource);
    }
}
