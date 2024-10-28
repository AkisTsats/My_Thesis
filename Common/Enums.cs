namespace Common
{
    public enum ResourceType
    {
        Undefined,
        Image,
        Document,
    }
    public enum UserType
    {
        Undergraduate,
        Postgraduate,
        Professor,
        Secretary,
        Other
    }

    public enum UserRole
    {
        Student,
        Staff,
        Admin
    }

    public enum Permissions
    {
        NoPermissions = 0,
        ReceivesAnnouncements = 1 << 0,
        ManageAnnouncements = 1 << 1,
        Admin = 1 << 2,
    }

}
