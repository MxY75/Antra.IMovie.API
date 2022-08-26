using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Entity;
using Antra.IMovie.Core.Model;
using Antra.IMovie.Infrascruture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Infrascruture.Service
{
    public class CookieLoginService : ICookieLoginService
    {
        private readonly IMovieCrmDBContext db;
        public CookieLoginService(IMovieCrmDBContext db)
        {
            this.db = db;
        }

        public async Task<User> cookieLogin(CookieUserLoginModel loginModel )
        {
            //select * from MovieCast join Movie on MovieCast.CastId =3;
           return await db.User.Where(x => x.Email == loginModel.Email && x.HashedPassword == loginModel.HashedPassword).FirstOrDefaultAsync();
         
            
        }


    }
}
