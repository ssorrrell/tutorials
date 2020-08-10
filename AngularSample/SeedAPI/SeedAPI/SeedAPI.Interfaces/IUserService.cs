using System;
using System.Collections.Generic;
using System.Text;

namespace SeedAPI.Interfaces
{
    public interface IUserService
    {
        public IUser Create(IUser domain);
        public bool Update(IUser domain);
        public bool Delete(int id);
        public IEnumerable<IUser> GetAll();
    }
}
