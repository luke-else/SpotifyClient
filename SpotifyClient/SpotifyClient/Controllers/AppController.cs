using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SpotifyClient.Models;
using SpotifyClient.Models.JSONModels;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace SpotifyClient.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AccessToken") != null)
            {
                ViewBag.ID = HttpContext.Session.GetString("AccessToken");
                return View();
            }
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            Login login = new Login();
            
            return Redirect($"https://accounts.spotify.com/authorize?client_id={login.ClientID}" +
                $"&response_type=code" +
                $"&redirect_uri={login.RedirectURI}" +
                $"&state={login.State}" +
                $"&scope={login.Scopes}");
        }

        public async Task<IActionResult> Authorise(string code, string state){

            Login login = new Login();

            Dictionary<string, string> Headers = new Dictionary<string, string>();
            Dictionary<string, string> Body = new Dictionary<string, string>();

            Body.Add("grant_type", "authorization_code");
            Body.Add("code", code);
            Body.Add("redirect_uri", login.RedirectURI);
            Body.Add("client_id", login.ClientID);
            Body.Add("client_secret", login.ClientSecret);



            var result = APIClient.Post("https://accounts.spotify.com/api/token", Headers, Body);
            var resultString = await result;

            Token user = JsonConvert.DeserializeObject<Token>(resultString);

            if (user.Error == null)
            {
                //Create a user Cookie with the data collected from the API.

                HttpContext.Session.SetString("AccessToken", user.AccessToken);
                HttpContext.Session.SetString("TokenType", user.RefreshToken);
                HttpContext.Session.SetInt32("Expiry", user.TokenExpiery);
                HttpContext.Session.SetString("RefreshToken", user.RefreshToken);

                return RedirectToAction("Index");

            }
            else
            {
                return Content(user.Error);
            }
        }

    }

}
