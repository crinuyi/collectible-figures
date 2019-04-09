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
        }
    }
}