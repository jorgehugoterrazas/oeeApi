using Volo.Abp.Modularity;

namespace oee;

[DependsOn(
    typeof(oeeApplicationModule),
    typeof(oeeDomainTestModule)
    )]
public class oeeApplicationTestModule : AbpModule
{

}
