using Antra.IMovie.Core.Entity;
using Antra.IMovie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Contracts.Service
{
   public interface ICookieLoginService {
        Task<User> cookieLogin(CookieUserLoginModel loginModel);

    }
}
