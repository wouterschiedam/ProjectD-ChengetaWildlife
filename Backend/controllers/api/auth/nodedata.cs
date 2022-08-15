using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace ProjectD_ChengetaWildlife.controllers
{
    
    
    [ApiController]
    public class Nodedata : Controller
    {
        [Route("api/auth/mqttdata")]
        [HttpGet]
        public string Get(int limit = 15, string order = "time", string where = "")
        {   
            Database database = new Database();
            DataTable data = database.BuildQuery($"SELECT time, pid, latitude, longitude, probability, soundtype, sound FROM mqttdata {where} ORDER BY {order} DESC LIMIT {limit}")
                .Select();
            database.Close();
            return JsonConvert.SerializeObject(data);
        }
        [Route("api/auth/mqttdata/pid")]
         [HttpGet]
        public string GetPid()
        {   
            Database database = new Database();
            DataTable data = database.BuildQuery($"SELECT pid FROM mqttdata ORDER BY pid DESC LIMIT 1")
                .Select();
            database.Close();
            return JsonConvert.SerializeObject(data);
        }

                [Route("api/auth/mqttdata/last")]
         [HttpGet]
        public string Getlast()
        {   
            Database database = new Database();
            DataTable data = database.BuildQuery($"SELECT time, pid, latitude, longitude, probability, soundtype  FROM mqttdata ORDER BY pid DESC LIMIT 1;")
                .Select();
            database.Close();
            return JsonConvert.SerializeObject(data);
        }


    }
}
