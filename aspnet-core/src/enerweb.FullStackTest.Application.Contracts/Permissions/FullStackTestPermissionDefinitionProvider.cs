using enerweb.FullStackTest.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace enerweb.FullStackTest.Permissions
{
    public class FullStackTestPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(FullStackTestPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(FullStackTestPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<FullStackTestResource>(name);
        }
    }
}
