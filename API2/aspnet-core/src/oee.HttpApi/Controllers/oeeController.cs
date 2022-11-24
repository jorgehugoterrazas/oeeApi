using oee.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace oee.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class oeeController : AbpControllerBase
{
    protected oeeController()
    {
        LocalizationResource = typeof(oeeResource);
    }
}
