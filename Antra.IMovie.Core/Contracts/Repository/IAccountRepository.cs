using Antra.IMovie.Core.Entity;
using Antra.IMovie.Core.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Contracts.Repository
{
   public interface IAccountRepository
    {

        Task<IdentityResult> SignUpAsync(SignUpModel user);
        Task<SignInResult> LoginAsync(SignInModel model);
        Task<IdentityResult> CreateRole();

    }
}
