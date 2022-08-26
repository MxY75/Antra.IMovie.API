using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Entity;
using Antra.IMovie.Core.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Infrascruture.Service
{
    public class AccountSerivceAsync : IAccountServiceAsync
    {
        private readonly IAccountRepository accountRepository;
        private readonly UserManager<AppUser> userManager;

        public AccountSerivceAsync(IAccountRepository  repo,UserManager<AppUser> um) {
            accountRepository = repo;
            userManager = um;
        }

  

        public async Task<SignInResultUser> LoginAsync(SignInModel model)
        {

           SignInResultUser user = new SignInResultUser();
           SignInResult result = await accountRepository.LoginAsync(model);
            user.SignResult = result;
            
            if (result.Succeeded) { 
               var usere = await userManager.FindByEmailAsync(model.Email);
                string id = await userManager.GetUserIdAsync(usere);
                user.UserId = id;
            }

            return user;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model )
        {
            IdentityResult  result = await accountRepository.SignUpAsync(model);
            if (result.Succeeded) {
                var usere = await userManager.FindByEmailAsync(model.Email);
                result =  await userManager.AddToRoleAsync(usere, "Regular");
            }
            return result;
        }
    }
}
