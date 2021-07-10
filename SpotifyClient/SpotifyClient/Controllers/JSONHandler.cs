using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpotifyClient.Models.JSONModels;

namespace SpotifyClient.Controllers
{
    public static class JSONHandler
    {
        public static string Serialise(object JSONObject)
        {
            return JsonConvert.SerializeObject(JSONObject);
        }

        public static object DeSerialise(string Data)
        {
            return JsonConvert.DeserializeObject<Token>(Data);
        }
    }
}
