
using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Entity;
using Antra.IMovie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Infrascruture.Service
{
    public class UserService : IUserService
    {

        IUserRepository userRepository;

        public UserService(IUserRepository _userRepository) {
            userRepository = _userRepository; 
        }
        public Task<int> InsertUser(UserPostModel user)
        {
            User entity = new User();
            entity.Id = user.Id;
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Email = user.Email;
            entity.PhoneNumber = user.PhoneNumber;
            entity.DateOfBirth = user.DateOfBirth;

            return userRepository.InsertAsync(entity);
        }
    }
}
