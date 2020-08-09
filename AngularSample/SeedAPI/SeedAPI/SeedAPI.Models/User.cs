using System;
using System.Collections.Generic;
using System.Text;

namespace SeedAPI.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
