using ExampleWithDapper.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ExampleWithDapper.Models
{
    public class UsersModel
    {
        public int UserID { get; set; } = default(int);
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int StatusID { get; set; } = default(int);
        public UserRolesModel? Role { get; set; }
        public StatusModel? Status { get; set; }
    }

    public class RequestUserModel 
    {
        public string Username { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int StatusID { get; set; } = default(int);
    }
}
