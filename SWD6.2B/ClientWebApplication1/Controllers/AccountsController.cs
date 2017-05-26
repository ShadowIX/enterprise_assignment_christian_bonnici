using BusinessLogic;
using System.Web.Mvc;
using System.Web.Security;

namespace ClientWebApplication1.Controllers
{
    public class AccountsController : Controller
    {

        public ActionResult Login()
        {
            ViewBag.value = "login";
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
           
            if (new AuthorsBL().Login(email, password))
            {
                //true: authenticate the user
                FormsAuthentication.SetAuthCookie(email, true);
                return RedirectToAction("Index", "Authors"); // actionName, controlloerName
            }
            else
            {
                ViewBag.Message = "Login failed. Try again..."; //tempdata
                ViewBag.value = "login";
            }

           
            return View();
        }
    }
}
