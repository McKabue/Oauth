using EPA.CUSTOM.AppUser;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EPA.CUSTOM.DAL
{
    public class EPAInitializer : DropCreateDatabaseIfModelChanges<EPAContext>  //DropCreateDatabaseAlways //DropCreateDatabaseIfModelChanges
    {
        protected override void Seed(EPAContext context)
        {
            var hasher = new PasswordHasher();
            var user = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            user.UserValidator = new UserValidator<ApplicationUser>(user) { AllowOnlyAlphanumericUserNames = false };
            user.Create(new ApplicationUser() { FirstName = "Charles", LastName = "Njogu", SurName = "Kabue", UserName = "IN16/20034/13", PasswordHash = hasher.HashPassword("1234567890") });
        }
    }
}