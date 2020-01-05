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

namespace HW7.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private DataAppContext db = new DataAppContext();

        public async Task<ActionResult> Index()
        {
            return View(await db.Posts.ToListAsync());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
