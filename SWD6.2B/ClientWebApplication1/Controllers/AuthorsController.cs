using BusinessLogic;
using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ClientWebApplication1.Controllers
{
    public class AuthorsController : Controller
    {
        AuthorsBL ab = new AuthorsBL();

        [Authorize]
        public ActionResult Index()
        {
            IQueryable<author> myUsers = ab.GetAuthors();
            return View(myUsers);
        }

        public ActionResult Register()
        {   
            return View();
        }

        [HttpPost]
        public ActionResult Register(author au)
        {
            bool check = ab.checkIfUserExists(au.email);

            if (check == true)
            {
                ViewBag.Message = "Author with this email already exists!! Creation Failed.";
            }
            else
            {
                try
                {
                    ab.Register(au);
                    ViewBag.Message = "If fields are met, author is created successfully!";
                }
                catch(Exception e)
                {
                    ViewBag.Message = "Error while creating this Author!";
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult Info(int authorID)
        {
            author auth = ab.getAuthorById(authorID);
            return View(auth);
        }

        [Authorize]
        public ActionResult UserInfo(string email)
        {
            author auth = ab.GetAuthor(email);
            return View(auth);
        }



        [Authorize]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(author au)
        {

            try
            {
                ab.UpdateAuthor(au);
                ViewBag.Message = "Author " + au.authorID + " got Updated";
            }
            catch(Exception e)
            {
                ViewBag.Message = "Author " + au.authorID + " update failed";
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int authorID)
        {
            try
            {
                ab.RemoveAuthor(authorID);
                ViewBag.Message = "Author " + authorID + " got Deleted";
            }

            catch(Exception e)
            {
                ViewBag.Message = "Author " + authorID + " could not get Deleted";
            }
            return View();
        }
    }
}