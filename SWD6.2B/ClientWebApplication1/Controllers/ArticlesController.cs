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
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace ClientWebApplication1
{
    public class ArticlesController : Controller
    {
        ArticlesBL ab = new ArticlesBL();

        [Authorize]
        public ActionResult Index()
        {
            IQueryable<article> myArticles = ab.Getarticles();
            return View(myArticles);
        }

        [Authorize]
        public ActionResult AddArticle()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddArticle(article au, HttpPostedFileBase file)
        {
            author Auth = new AuthorsBL().GetAuthor(HttpContext.User.Identity.Name);
            au.authorID = new AuthorsBL().GetAuthorID(Auth);
            au.articleID = new AuthorsBL().GetArticlesCount();


           // au.imageUrl = @"/Images/Help"; //Default Image.

            if (file != null)
            {
               /* byte[] fileSignature = new byte[11];
                file.InputStream.Read(fileSignature, 0, 11);

                file.InputStream.Position = 0;
                string imageExtension = Path.GetExtension(file.FileName);
                string filename = Guid.NewGuid().ToString() + imageExtension;
                string relativePath = @"/Images/" + filename;

                //absolute path is used to store the physical file
                //saving the image to the Images folder
                string absolutePath = Server.MapPath(@"\Images") + @"\" + filename;
                file.SaveAs(absolutePath);
                au.imageUrl = relativePath;
                */

                CloudStorageAccount csa = AzureClass.getConnectionString();
                CloudBlobClient cbc = csa.CreateCloudBlobClient();
                CloudBlobContainer cbct = cbc.GetContainerReference("christianbonici");

                if (cbct.CreateIfNotExists())
                {
                    cbct.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                }

                string imageName = Guid.NewGuid().ToString() + "-" + Path.GetExtension(file.FileName);
                CloudBlockBlob cbb = cbct.GetBlockBlobReference(imageName);
                cbb.Properties.ContentType = file.ContentType;
                cbb.UploadFromStream(file.InputStream);
                au.imageUrl = cbb.Uri.ToString();

            }


            switch (au.category)
            {
                case "national":
                    au.category = au.category.ToLower();
                    break;

                case "overseas":
                    au.category = au.category.ToLower();
                    break;

                case "sports":
                    au.category = au.category.ToLower();
                    break;

                case "opinion":
                    au.category = au.category.ToLower();
                    break;
                case "travel":
                    au.category = au.category.ToLower();
                    break;
                default:
                    au.category = "odd";
                    break;
            }
          
            try
            {
                ab.CreateArticle(au);
                ViewBag.Message = "Article Created Successfully!";
            }

            catch(Exception e)
            {
                ViewBag.Message = "Failed at creating Article! ";
            }
          
            return View();
        }

     /*   [HttpGet]
        [Authorize]
        public ActionResult UploadImage(int articleID)
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult UploadImage(int articleID,HttpPostedFileBase file)
        {
            try
            {
                byte[] fileSignature = new byte[11];
                file.InputStream.Read(fileSignature, 0, 11);
                
                file.InputStream.Position = 0;     
                string imageExtension = System.IO.Path.GetExtension(file.FileName);
                string filename = Guid.NewGuid().ToString() + imageExtension;
                string relativePath = @"/Images/" + filename;
               
                //absolute path is used to store the physical file
                //saving the image to the Images folder
                string absolutePath = Server.MapPath(@"\Images") + @"\" + filename;
                file.SaveAs(absolutePath);
                new ArticlesBL().UpdateImage(relativePath, 1);

                    ViewBag.Message = "Image Uploaded!";
            }
            catch
            {
                ViewBag.Message = "Image was not uploaded";
            }
            return View();
        }

    */

        [Authorize]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(article au)
        {
            author Auth = new AuthorsBL().GetAuthor(HttpContext.User.Identity.Name);
            au.authorID = new AuthorsBL().GetAuthorID(Auth);
            article art = new ArticlesBL().Getarticle(au.articleID);
            au.imageUrl = art.imageUrl;
            ab.Updatearticle(au);

            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int articleID)
        {
            try
            {
                ab.Removearticle(articleID);
                ViewBag.Message = "Article " + articleID + " got Deleted";
            }

            catch(Exception e)
            {
                ViewBag.Message = "Article " + articleID + " could not be deleted";
            }


            return RedirectToAction("Index");
        }
    }
}