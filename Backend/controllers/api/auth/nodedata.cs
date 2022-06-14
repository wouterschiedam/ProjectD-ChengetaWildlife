using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace ProjectD_ChengetaWildlife.controllers
{
    
    [Route("api/auth/mqttdata")]
    [ApiController]
    public class Nodedata : Controller
    {
        [HttpGet]
        public string Get(int limit = 15, string order = "time", string where = "")
        {   
            Database database = new Database();
            DataTable data = database.BuildQuery($"SELECT time, pid, latitude, longitude, probability, soundtype, sound FROM mqttdata {where} ORDER BY {order} DESC LIMIT {limit}")
                .Select();
            database.Close();
            return JsonConvert.SerializeObject(data);
        }
    }
}
