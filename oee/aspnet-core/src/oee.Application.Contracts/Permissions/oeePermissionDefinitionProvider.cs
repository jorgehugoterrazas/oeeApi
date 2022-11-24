using oee.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace oee.Permissions;

public class oeePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(oeePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(oeePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<oeeResource>(name);
    }
}
