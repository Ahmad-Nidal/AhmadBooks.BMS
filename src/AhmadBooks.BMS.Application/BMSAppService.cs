using System;
using System.Collections.Generic;
using System.Text;
using AhmadBooks.BMS.Localization;
using Volo.Abp.Application.Services;

namespace AhmadBooks.BMS;

/* Inherit your application services from this class.
 */
public abstract class BMSAppService : ApplicationService
{
    protected BMSAppService()
    {
        LocalizationResource = typeof(BMSResource);
    }
}
