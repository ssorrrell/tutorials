using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

using SeedAPI.Interfaces;

namespace SeedAPI.Repositories
{
    public interface IUserRepository
    {
        public IUser Save(IUser user);
        public bool Update(IUser user);
        public bool Delete(int id);
        public IEnumerable<IUser> GetAll();
    }
}
