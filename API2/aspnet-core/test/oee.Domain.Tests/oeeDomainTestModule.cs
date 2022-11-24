using oee.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace oee;

[DependsOn(
    typeof(oeeEntityFrameworkCoreTestModule)
    )]
public class oeeDomainTestModule : AbpModule
{

}
