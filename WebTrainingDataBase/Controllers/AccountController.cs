using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTrainingDataBase.Contract;
using WebTrainingDataBase.Services;
using WebTrainingDataBase.ViewModels;

namespace WebTrainingDataBase.Controllers
{
    public class AccountController : Controller
    {
        private readonly IServiceAccount service = null;

        public AccountController()
        {
            service = new AccountServices();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Email,Password")] AccountVM accountVM)
        {
            Models.Login user = new Models.Login
            {
                Email = accountVM.Email,
                Password = accountVM.Password
            };
            var email = service.Validate(user);
            if (!string.IsNullOrEmpty(email))
            {
                
                Session.Add("userSession", email);
                return RedirectToAction("Index","Profesiones");
            }
            ModelState.AddModelError("errorUser", "Error el usuario no fue encontrado");
            return View();
        }
    }
}