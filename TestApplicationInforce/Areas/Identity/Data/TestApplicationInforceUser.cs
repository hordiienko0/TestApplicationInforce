using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TestApplicationInforce.Models;

namespace TestApplicationInforce.Areas.Identity.Data;

// Add profile data for application users by adding properties to the TestApplicationInforceUser class
public class TestApplicationInforceUser : IdentityUser
{
    public IList<UserUrlModel> UserUrls { get; set; }
}

