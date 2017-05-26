using BusinessLogic;
using Common;
using Common.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiServiceProvider.Controllers
{
    public class UsersApiController : ApiController
    {
        public IQueryable GetUsers()
        {
            UsersBL bl = new UsersBL();
            var list = from u in bl.GetUsers()
                       //select new GetUsersModel()
                       //{
                       //    Username = u.Username,
                       //    FirstName = u.FirstName,
                       //    Surname = u.Surname
                       //};
                       select new { Username = u.Username, FirstName = u.FirstName, Surname=u.Surname };
            return list.AsQueryable();
        }

        public IQueryable GetUsers(string keyword)
        {
            UsersBL bl = new UsersBL();
            var list = from u in bl.GetUsers(keyword)
                       select new { Username = u.Username, FirstName = u.FirstName, Surname = u.Surname };
            return list.AsQueryable();
        }

        public HttpResponseMessage GetUserRoles(string username)
        {
            HttpResponseMessage message = null;

            UsersBL bl = new UsersBL();
            var roles =  bl.GetUserRoles(username);
            if (roles != null)
            {
                var list = from r in roles
                           select new { Id = r.Id, Title = r.Title };

                message = Request.CreateResponse(HttpStatusCode.OK, list);
            }
            else
            {
               //  message = Request.CreateResponse(HttpStatusCode.BadRequest, "Username not found");
               message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Username not found");
            }

            return message;
        }
    }

    //Returning data
    //Solution 1. You create a custom model(class) just to return the data.
    //Solution 2. You create an anonymous object on the fly to return the desired data.
}