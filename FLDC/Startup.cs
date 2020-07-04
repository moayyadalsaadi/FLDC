using Graduation_Project.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Graduation_Project.Startup))]
namespace Graduation_Project
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
            CreateUsers();
        }
        //add groups اضافة مجموعات
        public void CreateRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            if (!roleManager.RoleExists("Admin"))
            {
                role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Manager"))
            {
                role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }
        }
        //add users اضافة المستخدمين
        public void CreateUsers()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.Email = "fldczu.mail@gmail.com";
            user.UserName = "fldczu.mail@gmail.com";
            var check = userManager.Create(user, "fldc2020");
            if (check.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
