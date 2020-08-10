using System;
using System.Collections.Generic;
using System.Text;

using SeedAPI.Interfaces;
using SeedAPI.Models;

namespace SeedAPI.Services
{
    public class UserService : IUserService
    {
        private IUserRepository repository;

        public UserService(IUserRepository userRepository)
        {
            repository = userRepository;
        }

        public IUser Create(IUser domain)
        {
            return repository.Save(domain);
        }

        public bool Update(IUser domain)
        {
            return repository.Update(domain);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public IEnumerable<IUser> GetAll()
        {
            return repository.GetAll();
        }

    }
}
