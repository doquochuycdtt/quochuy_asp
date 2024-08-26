﻿using System.Linq;
using System.Web.Mvc;
using DoQuocHuy0352.Context;

namespace DoQuocHuy0352.Controllers
{
    public class ProfileController : Controller
    {
        private WebsiteEcomEntities1 _context;

        public ProfileController()
        {
            _context = new WebsiteEcomEntities1();
        }

        // GET: Profile/Index
        public ActionResult Index()
        {
            var email = Session["username"] as string;
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "User");
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }

            return View(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
