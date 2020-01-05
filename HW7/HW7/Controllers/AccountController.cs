using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW7.DataAccess;
using HW7.Models;
using HW7.ViewModels;
using System.Web.Security;

namespace HW7.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataAppContext db = new DataAppContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await db.Users.FirstOrDefaultAsync(x => x.Login == model.Login && x.Password == model.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    RedirectToAction("Index", "Users");
                }
                else
                {
                    ModelState.AddModelError("", "User is not exists");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await db.Users.FirstOrDefaultAsync(x => x.Login == model.Login);
                var userRole = await db.Roles.FirstOrDefaultAsync(x => x.Name == "user");
                if (user == null)
                {
                    db.Users.Add(new User { Login = model.Login, Password = model.Password, Role = userRole});
                    db.SaveChanges();
                    user = await db.Users.FirstOrDefaultAsync(x => x.Login == model.Login && x.Password==model.Password);

                    if (user != null)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User is already exists");
                }
            }

            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
