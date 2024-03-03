using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Group12_MobileShop.Areas.Identity.Data;

// Add profile data for application users by adding properties to the User class
public class User : IdentityUser
{
    public int Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Fullname { get; set; }
}

