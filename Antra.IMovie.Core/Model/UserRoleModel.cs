namespace Antra.IMovie.Core.Model
{
    public class UserRoleModel
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public UserModel User { get; set; }
        public RoleModel Role { get; set; }
    }
}