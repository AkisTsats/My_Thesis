namespace Common
{
    public class Common
    {
        public static IReadOnlyDictionary<UserRole, Permissions> RoleToPermissionMapping = new Dictionary<UserRole, Permissions>
        {
            { UserRole.Student, Permissions.ReceivesAnnouncements },
            { UserRole.Staff, Permissions.ManageAnnouncements },
            { UserRole.Admin, Permissions.ManageAnnouncements | Permissions.Admin }
        };
    }
}
