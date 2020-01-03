using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using WebApplication1.Models;

[assembly: OwinStartupAttribute(typeof(WebApplication1.Startup))]
namespace WebApplication1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }
    // In this method we will create default User roles and Admin user for login

    private void CreateRolesandUsers()
    {
      ApplicationDbContext context = new ApplicationDbContext();

      var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
      var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


      // In Startup iam creating first Admin Role and creating a default Admin User     
      if (!roleManager.RoleExists("Admin"))
      {


        // first we create Admin rool    
        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        role.Name = "Admin";
        roleManager.Create(role);

        //Here we create a Admin super user who will maintain the website                   

        var user = new ApplicationUser();
        user.UserName = "admin@admin.com";
        user.Email = "admin@admin.com";
        user.FirstName = "Admin";
        user.LastName = "Admin";
        user.EmailConfirmed = true;

        string userPWD = "Admin1$";

        var chkUser = userManager.Create(user, "Admin1$");

        //Add default User to Role Admin    
        if (chkUser.Succeeded)
        {
          var result1 = userManager.AddToRole(user.Id, "Admin");

        }
      }

      // creating Creating Customer role     
      if (!roleManager.RoleExists("Customer"))
      {
        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        role.Name = "Customer";
        roleManager.Create(role);

      }
    }

  }
}
