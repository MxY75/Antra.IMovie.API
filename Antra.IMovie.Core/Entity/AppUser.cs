using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antra.IMovie.Core.Entity
{
    public class AppUser : IdentityUser
    { 

        public new int Id { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string FirstName { get; set; }

        [Column (TypeName = "varchar(30)")]
        public string LastName { get; set; }
     
    }
}
