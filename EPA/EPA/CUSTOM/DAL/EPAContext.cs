using EPA.CUSTOM.AppUser;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPA.CUSTOM.DAL
{
    public class EPAContext : IdentityDbContext<ApplicationUser>
    {
        public EPAContext() : base("EPAContext") { }

    }
    
}