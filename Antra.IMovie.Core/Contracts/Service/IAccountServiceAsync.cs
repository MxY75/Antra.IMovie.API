using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Contracts.Service
{
    public  interface IAccountServiceAsync 
    {
       
        Task<IdentityResult> SignUpAsync(SignUpModel model);
        Task<SignInResultUser> LoginAsync(SignInModel model);
        Task<IdentityResult> CreateRole();



    }
}
