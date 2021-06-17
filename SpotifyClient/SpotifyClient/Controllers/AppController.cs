using Microsoft.AspNetCore.Mvc;
using SpotifyClient.Models;
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

        public IActionResult Authorise(string code, string state){
            return Content(code +"    " + state);
        }


        
    }
}
