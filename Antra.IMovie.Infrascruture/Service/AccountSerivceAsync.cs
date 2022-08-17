using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Contracts.Service;
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

        public AccountSerivceAsync(IAccountRepository  repo) {
            accountRepository = repo;
        }

        public Task<SignInResult> LoginAsync(SignInModel model)
        {
           return accountRepository.LoginAsync(model);
        }

        public Task<IdentityResult> SignUpAsync(SignUpModel model )
        {
           return accountRepository.SignUpAsync(model);
        }
    }
}
