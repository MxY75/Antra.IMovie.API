using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Antra.IMovie.Core.Model
{
    public class UserModel
    {
        public int Id { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "Varchar")]
        public string? FirstName { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "Varchar")]
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        [MaxLength(256)]
        [Column(TypeName = "Varchar")]
        public string? Email { get; set; }

        [MaxLength(1024)]
        [Column(TypeName = "Varchar")]
        public string? HashedPassword { get; set; }

        [MaxLength(1024)]
        [Column(TypeName = "Varchar")]
        public string? Salt { get; set; }


        [MaxLength(16)]
        [Column(TypeName = "Varchar")]
        public string? PhoneNumber { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDate { get; set; }
        public DateTime? LastLoginDateTime { get; set; }
        public bool? IsLocked { get; set; }
        public int? AccessFailedCount { get; set; }
        public IEnumerable<ReviewModel> UserReview { get; set; }
        public IEnumerable<FavoriteModel> UserFavorite { get; set; }
        public IEnumerable<PurchaseModel> UserPurchase { get; set; }
        public IEnumerable<UserRoleModel> UserName { get; set; }
    }
}
