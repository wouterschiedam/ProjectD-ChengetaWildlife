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

        [Route("api/auth/mqttdata/message")]
         [HttpGet]
        public string ReportList()
        {   
            // string[] events = HttpContext.Request.Form["message"];
            Database database = new Database();
            DataTable events = database.BuildQuery($"SELECT * FROM mqttdata WHERE time >= NOW() - INTERVAL 168 HOURS").Select();

            int gunshotEvents = 0;
            int animalEvents = 0;
            int otherEvents = 0;
            int vehicleEvents = 0;
            int total = gunshotEvents + animalEvents + otherEvents + vehicleEvents;

            foreach (DataRow ev in events.Rows ){
                if (ev["soundtype"].ToString() == "gunshot") gunshotEvents++;        
                else if (ev["soundtype"].ToString() == "animal") animalEvents++;
                else if (ev["soundtype"].ToString() == "unknown") otherEvents++;
                else if (ev["soundtype"].ToString() == "vehicle") vehicleEvents++;                       
            }

            string message = $"Last weeks total events: {total}.\n" +
            $"of which {gunshotEvents} where gunshot events,\n" + 
            $"and {animalEvents} where animal events,\n" +
            $"also {vehicleEvents} where vehicle events," +
            $"and at last {otherEvents} where unknown events!";

            database.Close();
            return message;
        }


    }
}
