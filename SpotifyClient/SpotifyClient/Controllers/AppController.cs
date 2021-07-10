using Microsoft.AspNetCore.Mvc;
using SpotifyClient.Models;
using SpotifyClient.Models.JSONModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyClient.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
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

            Token user = (Token)JSONHandler.DeSerialise(resultString);

            return Content($"{user.AccessToken}");
        }

    }

}
