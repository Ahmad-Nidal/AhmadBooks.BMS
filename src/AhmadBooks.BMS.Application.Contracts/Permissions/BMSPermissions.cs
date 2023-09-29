namespace AhmadBooks.BMS.Permissions;

public static class BMSPermissions
{
    public const string GroupName = "BMS";

    public static class Groups
    {
        public const string Default = GroupName + ".Groups";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
