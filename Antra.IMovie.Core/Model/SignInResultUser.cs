using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Model
{
    public class SignInResultUser
    {
        public SignInResult SignResult  { get; set; }
        public string UserId { get; set; } 
       
    }
}
