
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antra.IMovie.Core.Entity
{
    public class Role
    {
        public int Id { get; set; }

        [Column(TypeName ="varchar")]
        public string? Name { get; set; }
        public List<UserRole>? RoleName { get; set; }
    }
}