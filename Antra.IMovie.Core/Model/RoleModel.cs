namespace Antra.IMovie.Core.Model
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<UserRoleModel>? RoleName { get; set; }
    }
}