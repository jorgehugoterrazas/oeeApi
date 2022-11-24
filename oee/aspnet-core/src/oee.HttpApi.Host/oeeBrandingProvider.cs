using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace oee;

[Dependency(ReplaceServices = true)]
public class oeeBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "oee";
}
