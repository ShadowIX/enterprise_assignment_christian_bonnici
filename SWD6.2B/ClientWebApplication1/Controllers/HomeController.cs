using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientWebApplication1.CurrencyReference;
using ClientWebApplication1.UnitConverterReference;
using DataAccess;
using Common;

namespace ClientWebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        ArticlesRepository ar = new ArticlesRepository();
        AuthorsRepository auth = new AuthorsRepository();

        [Authorize]
        public ActionResult Index()
        {

            if (HttpContext.User.Identity.Name == null)
            {
                return RedirectToAction("Login", "Accounts");
            }

            else
            {
                IQueryable<article> myArticles = ar.Getarticles();
                return View(myArticles);
            }
        }

        [Authorize]
        public ActionResult Category(string category)
        {
           
            List<article> filtered = new List<article>();
            try
            {
                IQueryable<article> art = ar.Getarticles();
                List<article> myArticles = new List<article>();
                myArticles = art.ToList();

                int counter = myArticles.Count();
                for (int i = 0; i < counter; i++)
                {
                    ViewBag.Message = myArticles.ElementAt(0).article_name;
                    if (myArticles.ElementAt(i).category.ToString() == category.ToLower())
                    {
                        filtered.Add(myArticles.ElementAt(i));
                    }
                }
                counter = filtered.Count();
                while (counter > 5)
                {
                    filtered.RemoveAt(0);
                    counter--;
                }
                ViewBag.Message = "Records Loaded successfully for category " + category.ToLower();
            }
            catch (Exception e)
            {
                ViewBag.Message = "Error loading Data";
            }
            filtered.Reverse();

            string category_value = category.ToLower();
            ViewBag.Value = category_value;
            return View(filtered.AsQueryable());
        }

        [Authorize]
        public ActionResult AuthorIndex()
        {
            IQueryable<author> myAuthors = auth.GetAuthors();
            List<article> filtered = new List<article>();

            foreach (author au in myAuthors)
            {
                IQueryable<article> myArticles = ar.GetarticlesByAuthor(au.authorID);
                List<article> currentArticles = myArticles.ToList();
                myArticles.ToList();
                List<article> objListOrder =
                     currentArticles.OrderBy(order => order.authorID).ToList();
                //myArticles.Reverse();
                int counter = 0;
                try
                {
                    while (counter < 5 && currentArticles.ElementAt(counter) != null)
                    {
                        filtered.Add(currentArticles.ElementAt(counter));
                        counter++;
                    }
                }
                catch (Exception e)
                { }
            }
            ViewBag.Value = "authorIndex";
            return View(filtered);
        }
        [Authorize]
        public ActionResult Author(string email)
        {

            author chosen = auth.GetAuthor(email);

            List<article> filtered = new List<article>();
            try
            {
                IQueryable<article> art = ar.Getarticles();
                List<article> myArticles = new List<article>();
                myArticles = art.ToList();

                int counter = myArticles.Count();
                for (int i = 0; i < counter; i++)
                {
                    ViewBag.Message = myArticles.ElementAt(0).article_name;
                    if (myArticles.ElementAt(i).authorID == chosen.authorID)
                    {
                        filtered.Add(myArticles.ElementAt(i));
                    }
                }
                counter = filtered.Count();
                while (counter > 5)
                {
                    filtered.RemoveAt(0);
                    counter--;
                }
                ViewBag.Message = "Records Loaded successfully for :" + email;
            }
            catch (Exception e)
            {
                ViewBag.Message = "Error loading Data";
            }
            filtered.Reverse();
            ViewBag.Value = "authorIndex";
            return View(filtered.AsQueryable());
        }
        [Authorize]
        public ActionResult Details(int articleID)
        {
            article selected = ar.Getarticle(articleID);
            return View(selected);
        }

    }
}