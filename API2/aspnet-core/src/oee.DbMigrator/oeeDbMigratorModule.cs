using oee.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace oee.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(oeeEntityFrameworkCoreModule),
    typeof(oeeApplicationContractsModule)
    )]
public class oeeDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
