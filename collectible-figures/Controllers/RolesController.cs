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
    public class RolesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

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

        //_____________________________________________________________
        // GET: Roles
        public ActionResult Index() {
            if (User.Identity.IsAuthenticated) {
                if (User.IsInRole("Admin")) {
                    return View(context.Roles.ToList());
                }
                else return RedirectToAction("Index", "Home");
            }
            else return RedirectToAction("Index", "Home");

            /*if (User.Identity.IsAuthenticated) {
                if (!isAdminUser()) {
                    return RedirectToAction("Index", "Home");
                }
                else {
                    var Roles = context.Roles.ToList();
                    return View(Roles);
                }
            }
            else {
                return RedirectToAction("Index", "Home");
            }*/
        }
    }
}