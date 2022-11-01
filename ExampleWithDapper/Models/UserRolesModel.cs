namespace ExampleWithDapper.Models
{
    public class UserRolesModel
    {
        public int UserRoleID { get; set; } = default(int);
        public int UserID { get; set; } = default(int);
        public int RoleID { get; set; } = default(int);
        public string RoleName { get; set; } = string.Empty;
    }

    public enum RoleStatus
    {
        Admin = 1,
        Member = 2,
    }
}
