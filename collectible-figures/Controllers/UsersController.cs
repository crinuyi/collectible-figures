using collectible_figures.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace collectible_figures.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        public Boolean isAdminUser() {
            if (User.Identity.IsAuthenticated) {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin") {
                    return true;
                }
                else {
                    return false;
                }
            }
            return false;
        }

        //___________________________________________________________________
        // GET: Users
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated) {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";
                if(User.IsInRole("Admin")) {
                    ViewBag.displayMenu = "Yes";
                }
                return View();
            }
            else {
                ViewBag.Name = "Nie jesteś zalogowany!";
            }
            return View();
            /*if (User.Identity.IsAuthenticated) {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";

                if (isAdminUser()) {
                    ViewBag.displayMenu = "Yes";
                }
                return View();
            }
            else {
                ViewBag.Name = "Nie jesteś zalogowany!";
            }
            return View();*/
        }
    }
}