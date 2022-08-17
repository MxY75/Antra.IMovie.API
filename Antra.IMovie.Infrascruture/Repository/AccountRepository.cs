using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Model;
using Microsoft.AspNetCore.Identity;
using Antra.IMovie.Core.Entity;

namespace Antra.IMovie.Infrascruture.Repository
{
    public class AccountRepository : IAccountRepository {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        public AccountRepository(UserManager<AppUser>m, SignInManager<AppUser> signInManager)
        {
            userManager = m;
            this.signInManager = signInManager;
        }

        public Task<IdentityResult> SignUpAsync(SignUpModel user)
        {
            AppUser appUser = new AppUser();
            appUser.FirstName = user.FirstName;
            appUser.LastName = user.LastName;
            appUser.Email = user.Email;
            appUser.UserName = user.Email;

           return userManager.CreateAsync(appUser, user.Password);
        }
       public Task<SignInResult> LoginAsync(SignInModel model)
        {

           return signInManager.PasswordSignInAsync(model.Email, model.Password, model.Remember, false);
        }
    }       
}
