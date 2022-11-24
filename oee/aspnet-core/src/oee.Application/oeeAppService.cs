using System;
using System.Collections.Generic;
using System.Text;
using oee.Localization;
using Volo.Abp.Application.Services;

namespace oee;

/* Inherit your application services from this class.
 */
public abstract class oeeAppService : ApplicationService
{
    protected oeeAppService()
    {
        LocalizationResource = typeof(oeeResource);
    }
}
