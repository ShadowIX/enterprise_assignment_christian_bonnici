using ClientWebApplication1.Models;
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
    public class UsersController : Controller
    {
        //
        // GET: /Users/
 

        public async Task<ActionResult>  Index()
        {
            HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Add("apikey", "xxxxxxx");
            HttpResponseMessage message = await client.GetAsync("http://localhost:49700/api/UsersApi/GetUsers");

            string data = message.Content.ReadAsStringAsync().Result;

           //optional
            dynamic users = JsonConvert.DeserializeObject(data);
            List<UserModel> myUsers = new List<UserModel>();
            foreach(var user in users)
            {
                string str = Convert.ToString(user.FirstName);
                str = str.ToUpper();
                user.FirstName = str;

                UserModel m = new UserModel() { FirstName = user.FirstName, Surname = user.Surname };
                myUsers.Add(m);

            }

          //  string dataUpper = JsonConvert.SerializeObject(users);

            //---

            return View(myUsers);
             
        }

    }
}
