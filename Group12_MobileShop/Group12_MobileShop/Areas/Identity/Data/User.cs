using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Group12_MobileShop.Models;
using Microsoft.AspNetCore.Identity;

namespace Group12_MobileShop.Areas.Identity.Data;

// Add profile data for application users by adding properties to the User class
public class User : IdentityUser
{
    public string username { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public string full_name { get; set; }
}

