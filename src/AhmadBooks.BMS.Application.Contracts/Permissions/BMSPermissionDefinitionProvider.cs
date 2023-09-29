using AhmadBooks.BMS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AhmadBooks.BMS.Permissions;

public class BMSPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BMSPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BMSPermissions.MyPermission1, L("Permission:MyPermission1"));

        var groupsPermission = myGroup.AddPermission(BMSPermissions.Groups.Default, L("Permission:Groups"));
        groupsPermission.AddChild(BMSPermissions.Groups.Create, L("Permission:Groups:Create"));
        groupsPermission.AddChild(BMSPermissions.Groups.Edit, L("Permission:Groups:Edit"));
        groupsPermission.AddChild(BMSPermissions.Groups.Delete, L("Permission:Groups:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BMSResource>(name);
    }
}
