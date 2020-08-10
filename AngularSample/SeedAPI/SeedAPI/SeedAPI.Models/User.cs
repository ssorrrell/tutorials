using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using SeedAPI.Interfaces;

namespace SeedAPI.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
