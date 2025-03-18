using System.Web.Mvc;
using WebTrainingDataBase.Contract;
using WebTrainingDataBase.Filter;
using WebTrainingDataBase.Infrestructura;
using WebTrainingDataBase.Security;
using WebTrainingDataBase.Services;

namespace WebTrainingDataBase.Controllers
{
    public class AuthController : Controller
    {
        private IClaimManager claimManager;
        private readonly IAuthServices authServices = null;

        public AuthController()
        {
            claimManager = new ClaimManager();
            authServices = new AuthServices();
        }
        // GET: Auth
        [HttpGet]
        [ExceptionFilter]
        [AllowAnonymous]

        public ActionResult Login(string returnurl = "")
        {
            ViewBag.ReturnUrl = returnurl;
            return View();
        }


        [HttpGet]
        public ActionResult LogOut()
        {
            claimManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult ChangePassword(string Oldpassword, string NewPassword)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!Oldpassword.Equals(NewPassword))
                {
                    authServices.UpdatePassword(User.Identity.Name, Oldpassword, NewPassword);

                }
            }
            return View();
        }
    }
}